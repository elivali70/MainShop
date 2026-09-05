using System;
using System.Collections.Generic;
using App.Infarstructure.DataBase.SqlServer.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Infarstructure.DataBase.SqlServer.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Barnd> Barnds { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Collection> Collections { get; set; }

    public virtual DbSet<CollectionProduct> CollectionProducts { get; set; }

    public virtual DbSet<Colour> Colours { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<EditorOperator> EditorOperators { get; set; }

    public virtual DbSet<FileType> FileTypes { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductColour> ProductColours { get; set; }

    public virtual DbSet<ProductFile> ProductFiles { get; set; }

    public virtual DbSet<ProductTag> ProductTags { get; set; }

    public virtual DbSet<ProductView> ProductViews { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<SubmitOperator> SubmitOperators { get; set; }

    public virtual DbSet<SubmitUser> SubmitUsers { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<TagCategory> TagCategories { get; set; }

    public virtual DbSet<ViewrUser> ViewrUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=ShopProjectDB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Barnd>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasIndex(e => e.ParentCategoryId, "IX_Categories_ParentCategoryId");

            entity.Property(e => e.Name).HasMaxLength(150);

            entity.HasOne(d => d.ParentCategory).WithMany(p => p.InverseParentCategory).HasForeignKey(d => d.ParentCategoryId);
        });

        modelBuilder.Entity<CollectionProduct>(entity =>
        {
            entity.HasIndex(e => e.CollectionId, "IX_CollectionProducts_CollectionId");

            entity.HasIndex(e => e.ProductId, "IX_CollectionProducts_ProductId");

            entity.HasOne(d => d.Collection).WithMany(p => p.CollectionProducts)
                .HasForeignKey(d => d.CollectionId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Product).WithMany(p => p.CollectionProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Colour>(entity =>
        {
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasIndex(e => e.EditoroperatorId, "IX_Comments_EditoroperatorId");

            entity.HasIndex(e => e.ParentCommentId, "IX_Comments_ParentCommentId");

            entity.HasIndex(e => e.ProductId, "IX_Comments_ProductId");

            entity.HasIndex(e => e.StatusId, "IX_Comments_StatusId");

            entity.HasIndex(e => e.SubmitUserId, "IX_Comments_SubmitUserId");

            entity.Property(e => e.Title).HasMaxLength(500);

            entity.HasOne(d => d.Editoroperator).WithMany(p => p.Comments).HasForeignKey(d => d.EditoroperatorId);

            entity.HasOne(d => d.ParentComment).WithMany(p => p.InverseParentComment).HasForeignKey(d => d.ParentCommentId);

            entity.HasOne(d => d.Product).WithMany(p => p.Comments)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Status).WithMany(p => p.Comments)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.SubmitUser).WithMany(p => p.Comments)
                .HasForeignKey(d => d.SubmitUserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<FileType>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.ValidExtentions).HasMaxLength(150);
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.HasIndex(e => e.BrandId, "IX_Models_BrandId");

            entity.HasIndex(e => e.BrandId1, "IX_Models_BrandId1");

            entity.HasIndex(e => e.ParentModelId, "IX_Models_ParentModelId");

            entity.Property(e => e.Name).HasMaxLength(200);

            entity.HasOne(d => d.Brand).WithMany(p => p.ModelBrands)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.BrandId1Navigation).WithMany(p => p.ModelBrandId1Navigations).HasForeignKey(d => d.BrandId1);

            entity.HasOne(d => d.ParentModel).WithMany(p => p.InverseParentModel).HasForeignKey(d => d.ParentModelId);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.BrandId, "IX_Products_BrandId");

            entity.HasIndex(e => e.CategoryId, "IX_Products_CategoryId");

            entity.HasIndex(e => e.ModelId, "IX_Products_ModelId");

            entity.HasIndex(e => e.SubmitOperatorId, "IX_Products_SubmitOperatorId");

            entity.Property(e => e.Name).HasMaxLength(300);
            entity.Property(e => e.Weight).HasColumnType("decimal(18, 3)");

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Model).WithMany(p => p.Products).HasForeignKey(d => d.ModelId);

            entity.HasOne(d => d.SubmitOperator).WithMany(p => p.Products)
                .HasForeignKey(d => d.SubmitOperatorId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ProductColour>(entity =>
        {
            entity.HasIndex(e => e.ColourId, "IX_ProductColours_ColourId");

            entity.HasIndex(e => e.ProductId, "IX_ProductColours_ProductId");

            entity.HasOne(d => d.Colour).WithMany(p => p.ProductColours)
                .HasForeignKey(d => d.ColourId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductColours)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ProductFile>(entity =>
        {
            entity.HasIndex(e => e.FileTypeId, "IX_ProductFiles_FileTypeId");

            entity.HasIndex(e => e.ProductId, "IX_ProductFiles_ProductId");

            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.FileType).WithMany(p => p.ProductFiles)
                .HasForeignKey(d => d.FileTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductFiles)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ProductTag>(entity =>
        {
            entity.HasIndex(e => e.ProductId, "IX_ProductTags_ProductId");

            entity.HasIndex(e => e.TagId, "IX_ProductTags_TagId");

            entity.Property(e => e.Value).HasMaxLength(500);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductTags)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Tag).WithMany(p => p.ProductTags)
                .HasForeignKey(d => d.TagId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ProductView>(entity =>
        {
            entity.HasIndex(e => e.ProductId, "IX_ProductViews_ProductId");

            entity.HasIndex(e => e.ViewerUserId, "IX_ProductViews_ViewerUserId");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductViews)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ViewerUser).WithMany(p => p.ProductViews)
                .HasForeignKey(d => d.ViewerUserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasIndex(e => e.TagCategoryId, "IX_Tags_TagCategoryId");

            entity.Property(e => e.Name).HasMaxLength(200);

            entity.HasOne(d => d.TagCategory).WithMany(p => p.Tags)
                .HasForeignKey(d => d.TagCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<TagCategory>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
