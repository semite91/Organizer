using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Organizer_Data.Models
{
    public partial class OrganizerContext : DbContext
    {
        public OrganizerContext()
        {
        }

        public OrganizerContext(DbContextOptions<OrganizerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DocumentContent> DocumentContent { get; set; }
        public virtual DbSet<DocumentDocument> DocumentDocument { get; set; }
        public virtual DbSet<DocumentFolder> DocumentFolder { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-EPJOH8P\\SQLEXPRESS;Initial Catalog=Organizer;Integrated Security=True;Pooling=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<DocumentContent>(entity =>
            {
                entity.ToTable("Document_Content");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.DeleteUserId).HasColumnName("DeleteUserID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");
            });

            modelBuilder.Entity<DocumentDocument>(entity =>
            {
                entity.ToTable("Document_Document");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ContentId).HasColumnName("ContentID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.DeleteUserId).HasColumnName("DeleteUserID");

                entity.Property(e => e.FileName).HasMaxLength(200);

                entity.Property(e => e.FolderId).HasColumnName("FolderID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");

                entity.HasOne(d => d.Content)
                    .WithMany(p => p.DocumentDocument)
                    .HasForeignKey(d => d.ContentId)
                    .HasConstraintName("FK_Document_Document_Document_Content");

                entity.HasOne(d => d.Folder)
                    .WithMany(p => p.DocumentDocument)
                    .HasForeignKey(d => d.FolderId)
                    .HasConstraintName("FK_Document_Document_Document_Folder");
            });

            modelBuilder.Entity<DocumentFolder>(entity =>
            {
                entity.ToTable("Document_Folder");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ChildIds)
                    .HasColumnName("ChildIDs")
                    .HasMaxLength(400);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ColorCode).HasMaxLength(10);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.DeleteUserId).HasColumnName("DeleteUserID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.ParentIds)
                    .HasColumnName("ParentIDs")
                    .HasMaxLength(200);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Document_Folder_ParentID");
            });
        }
    }
}
