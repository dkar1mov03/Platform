using Microsoft.EntityFrameworkCore;
using RecruitmentPlatform.Domain.Entities.Assets;
using RecruitmentPlatform.Domain.Entities.ChatMessengers;
using RecruitmentPlatform.Domain.Entities.Employeers;
using RecruitmentPlatform.Domain.Entities.JobAplications;
using RecruitmentPlatform.Domain.Entities.JobLists;
using RecruitmentPlatform.Domain.Entities.JobSeekers;

namespace RecruitmentPlatform.Data.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
    public DbSet<ChatMessenger> ChatMessengers { get; set; }
    public DbSet<Employeer> Employeers { get; set; }
    public DbSet<JobAplication> JobAplications { get; set;}
    public DbSet<JobList> JobLists { get; set; }
    public DbSet<JobSeeker> JobSeekers { get; set; }
    public DbSet<Asset> Assets { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<JobList>()
            .HasOne(j => j.Employeer);
            
            
    }
}
