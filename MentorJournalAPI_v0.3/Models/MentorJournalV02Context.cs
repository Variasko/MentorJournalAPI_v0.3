using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MentorJournalAPI_v0._3.Models
{


    public partial class MentorJournalV02Context : DbContext
    {
        public MentorJournalV02Context()
        {
        }

        public MentorJournalV02Context(DbContextOptions<MentorJournalV02Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Activist> Activists { get; set; }

        public virtual DbSet<ActivityType> ActivityTypes { get; set; }

        public virtual DbSet<Admin> Admins { get; set; }

        public virtual DbSet<AttendClassHour> AttendClassHours { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<ClassHour> ClassHours { get; set; }

        public virtual DbSet<DegreeOfKinship> DegreeOfKinships { get; set; }

        public virtual DbSet<Dormitory> Dormitories { get; set; }

        public virtual DbSet<Group> Groups { get; set; }

        public virtual DbSet<Hobbie> Hobbies { get; set; }

        public virtual DbSet<HobbieType> HobbieTypes { get; set; }

        public virtual DbSet<IndividualWordWithStudent> IndividualWordWithStudents { get; set; }

        public virtual DbSet<IndividualWorkWithParent> IndividualWorkWithParents { get; set; }

        public virtual DbSet<Mentor> Mentors { get; set; }

        public virtual DbSet<ObservationList> ObservationLists { get; set; }

        public virtual DbSet<Parent> Parents { get; set; }

        public virtual DbSet<ParentConference> ParentConferences { get; set; }

        public virtual DbSet<Person> People { get; set; }

        public virtual DbSet<SocialPassport> SocialPassports { get; set; }

        public virtual DbSet<SocialStatus> SocialStatuses { get; set; }

        public virtual DbSet<Specification> Specifications { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<StudentInGroup> StudentInGroups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Data Source=DESKTOP-J7F367J\\SQLEXPRESS;Initial Catalog=MentorJournal_v0.2;Integrated Security=True;Encrypt=False");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activist>(entity =>
            {
                entity.ToTable("Activist");

                entity.HasIndex(e => e.ActivityTypeId, "IX_Activist_ActivityTypeId");

                entity.HasIndex(e => e.StudentId, "IX_Activist_StudentId");

                entity.HasOne(d => d.ActivityType).WithMany(p => p.Activists).HasForeignKey(d => d.ActivityTypeId);

                entity.HasOne(d => d.Student).WithMany(p => p.Activists).HasForeignKey(d => d.StudentId);
            });

            modelBuilder.Entity<ActivityType>(entity =>
            {
                entity.ToTable("ActivityType");
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.PersonId);

                entity.ToTable("Admin");

                entity.Property(e => e.PersonId).ValueGeneratedNever();

                entity.HasOne(d => d.Person).WithOne(p => p.Admin).HasForeignKey<Admin>(d => d.PersonId);
            });

            modelBuilder.Entity<AttendClassHour>(entity =>
            {
                entity.ToTable("AttendClassHour");

                entity.HasIndex(e => e.ClassHourId, "IX_AttendClassHour_ClassHourId");

                entity.HasIndex(e => e.StudentId, "IX_AttendClassHour_StudentId");

                entity.HasOne(d => d.ClassHour).WithMany(p => p.AttendClassHours).HasForeignKey(d => d.ClassHourId);

                entity.HasOne(d => d.Student).WithMany(p => p.AttendClassHours).HasForeignKey(d => d.StudentId);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");
            });

            modelBuilder.Entity<ClassHour>(entity =>
            {
                entity.ToTable("ClassHour");
            });

            modelBuilder.Entity<DegreeOfKinship>(entity =>
            {
                entity.ToTable("DegreeOfKinship");
            });

            modelBuilder.Entity<Dormitory>(entity =>
            {
                entity.ToTable("Dormitory");

                entity.HasIndex(e => e.StudentId, "IX_Dormitory_StudentId");

                entity.HasOne(d => d.Student).WithMany(p => p.Dormitories).HasForeignKey(d => d.StudentId);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("Group");

                entity.HasIndex(e => e.SpecificationId, "IX_Group_SpecificationId");

                entity.HasOne(d => d.Specification).WithMany(p => p.Groups).HasForeignKey(d => d.SpecificationId);
            });

            modelBuilder.Entity<Hobbie>(entity =>
            {
                entity.ToTable("Hobbie");

                entity.HasIndex(e => e.HobbieTypeId, "IX_Hobbie_HobbieTypeId");

                entity.HasIndex(e => e.StudentId, "IX_Hobbie_StudentId");

                entity.HasOne(d => d.HobbieType).WithMany(p => p.Hobbies).HasForeignKey(d => d.HobbieTypeId);

                entity.HasOne(d => d.Student).WithMany(p => p.Hobbies).HasForeignKey(d => d.StudentId);
            });

            modelBuilder.Entity<HobbieType>(entity =>
            {
                entity.ToTable("HobbieType");
            });

            modelBuilder.Entity<IndividualWordWithStudent>(entity =>
            {
                entity.ToTable("IndividualWordWithStudent");

                entity.HasIndex(e => e.StudentId, "IX_IndividualWordWithStudent_StudentId");

                entity.HasOne(d => d.Student).WithMany(p => p.IndividualWordWithStudents).HasForeignKey(d => d.StudentId);
            });

            modelBuilder.Entity<IndividualWorkWithParent>(entity =>
            {
                entity.ToTable("IndividualWorkWithParent");

                entity.HasIndex(e => e.ParentId, "IX_IndividualWorkWithParent_ParentId");

                entity.HasOne(d => d.Parent).WithMany(p => p.IndividualWorkWithParents).HasForeignKey(d => d.ParentId);
            });

            modelBuilder.Entity<Mentor>(entity =>
            {
                entity.HasKey(e => e.PersonId);

                entity.ToTable("Mentor");

                entity.HasIndex(e => e.CategoryId, "IX_Mentor_CategoryId");

                entity.Property(e => e.PersonId).ValueGeneratedNever();

                entity.HasOne(d => d.Category).WithMany(p => p.Mentors).HasForeignKey(d => d.CategoryId);

                entity.HasOne(d => d.Person).WithOne(p => p.Mentor).HasForeignKey<Mentor>(d => d.PersonId);
            });

            modelBuilder.Entity<ObservationList>(entity =>
            {
                entity.ToTable("ObservationList");

                entity.HasIndex(e => e.StudentId, "IX_ObservationList_StudentId");

                entity.HasOne(d => d.Student).WithMany(p => p.ObservationLists).HasForeignKey(d => d.StudentId);
            });

            modelBuilder.Entity<Parent>(entity =>
            {
                entity.ToTable("Parent");

                entity.HasIndex(e => e.DegreeOfKinshipId, "IX_Parent_DegreeOfKinshipId");

                entity.HasIndex(e => e.StudentId, "IX_Parent_StudentId");

                entity.HasOne(d => d.DegreeOfKinship).WithMany(p => p.Parents).HasForeignKey(d => d.DegreeOfKinshipId);

                entity.HasOne(d => d.Student).WithMany(p => p.Parents).HasForeignKey(d => d.StudentId);
            });

            modelBuilder.Entity<ParentConference>(entity =>
            {
                entity.ToTable("ParentConference");

                entity.HasIndex(e => e.GroupId, "IX_ParentConference_GroupId");

                entity.HasOne(d => d.Group).WithMany(p => p.ParentConferences).HasForeignKey(d => d.GroupId);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.Property(e => e.Inn).HasColumnName("INN");
                entity.Property(e => e.Snils).HasColumnName("SNILS");
            });

            modelBuilder.Entity<SocialPassport>(entity =>
            {
                entity.ToTable("SocialPassport");

                entity.HasIndex(e => e.SocialStatusId, "IX_SocialPassport_SocialStatusId");

                entity.HasIndex(e => e.StudnetId, "IX_SocialPassport_StudnetId");

                entity.HasOne(d => d.SocialStatus).WithMany(p => p.SocialPassports).HasForeignKey(d => d.SocialStatusId);

                entity.HasOne(d => d.Studnet).WithMany(p => p.SocialPassports).HasForeignKey(d => d.StudnetId);
            });

            modelBuilder.Entity<SocialStatus>(entity =>
            {
                entity.ToTable("SocialStatus");
            });

            modelBuilder.Entity<Specification>(entity =>
            {
                entity.ToTable("Specification");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.PersonId);

                entity.ToTable("Student");

                entity.Property(e => e.PersonId).ValueGeneratedNever();

                entity.HasOne(d => d.Person).WithOne(p => p.Student).HasForeignKey<Student>(d => d.PersonId);
            });

            modelBuilder.Entity<StudentInGroup>(entity =>
            {
                entity.ToTable("StudentInGroup");

                entity.HasIndex(e => e.GroupId, "IX_StudentInGroup_GroupId");

                entity.HasIndex(e => e.StudentId, "IX_StudentInGroup_StudentId");

                entity.HasOne(d => d.Group).WithMany(p => p.StudentInGroups).HasForeignKey(d => d.GroupId);

                entity.HasOne(d => d.Student).WithMany(p => p.StudentInGroups).HasForeignKey(d => d.StudentId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}