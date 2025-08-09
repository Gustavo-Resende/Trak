using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Trak.Core.InvoiceAggregate;
using Trak.Core.PlayAggregate;
using Trak.Core.UserAggregate;
using Trak.Core.WorkoutAggregate;
using Valhalla.Lib.SharedKernel;

namespace Trak.Infrastructure.Data.PostgreSQL
{
    public class PgSqlDbContext(IServiceProvider serviceProvider,
                               DbContextOptions<PgSqlDbContext> options)
        : DbContext(options)
    {
        private readonly IDomainEventDispatcher? _domainEventDispatcher = serviceProvider?.GetService<IDomainEventDispatcher>();

        public DbSet<Play> Play => Set<Play>();
        public DbSet<Invoice> Invoice => Set<Invoice>();
        public DbSet<Workout> Workouts => Set<Workout>();
        public DbSet<User> User => Set<User>();
        public DbSet<Exercise> Exercises => Set<Exercise>();

        public void InitializeDatabase()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
                    .Select(e => e.Entity)
                    .Where(e => e.DomainEvents.Any())
                    .ToArray();

                if (_domainEventDispatcher is not null)
                {
                    await _domainEventDispatcher.DispatchEvents(entitiesWithEvents);
                }

                return result;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while saving changes to the PostgreSQL database.", ex);
            }
            finally
            {
                if (_domainEventDispatcher is not null)
                {
                    var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
                        .Select(e => e.Entity)
                        .Where(e => e.DomainEvents.Any())
                        .ToArray();

                    await _domainEventDispatcher.ClearEvents(entitiesWithEvents);
                }
            }
        }

        public override int SaveChanges() =>
            SaveChangesAsync().GetAwaiter().GetResult();
    }
}