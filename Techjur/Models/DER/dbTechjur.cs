namespace Techjur.Models.DER
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class dbTechjur : DbContext
    {
        public dbTechjur()
            : base("name=dbTechjur")
        {
        }

        public virtual DbSet<Acao> Acao { get; set; }
        public virtual DbSet<AcaoMovimento> AcaoMovimento { get; set; }
        public virtual DbSet<AcaoMovimentoDocumento> AcaoMovimentoDocumento { get; set; }
        public virtual DbSet<AcaoParte> AcaoParte { get; set; }
        public virtual DbSet<AcaoParteTipo> AcaoParteTipo { get; set; }
        public virtual DbSet<Assunto> Assunto { get; set; }
        public virtual DbSet<Classe> Classe { get; set; }
        public virtual DbSet<Movimento> Movimento { get; set; }
        public virtual DbSet<Notificacao> Notificacao { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<Rito> Rito { get; set; }
        public virtual DbSet<SegurancaLogEnvio> SegurancaLogEnvio { get; set; }
        public virtual DbSet<SegurancaUsuario> SegurancaUsuario { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acao>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Acao>()
                .Property(e => e.numeroProcesso)
                .IsUnicode(false);

            modelBuilder.Entity<Acao>()
                .HasMany(e => e.AcaoMovimento)
                .WithRequired(e => e.Acao)
                .HasForeignKey(e => e.idAcao);

            modelBuilder.Entity<Acao>()
                .HasMany(e => e.AcaoParte)
                .WithRequired(e => e.Acao)
                .HasForeignKey(e => e.idAcao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AcaoMovimento>()
                .Property(e => e.numeroProcesso)
                .IsUnicode(false);

            modelBuilder.Entity<AcaoMovimento>()
                .HasMany(e => e.AcaoMovimentoDocumento)
                .WithRequired(e => e.AcaoMovimento)
                .HasForeignKey(e => e.idAcaoMovimento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AcaoMovimentoDocumento>()
                .Property(e => e.documentoMime)
                .IsUnicode(false);

            modelBuilder.Entity<AcaoMovimentoDocumento>()
                .HasMany(e => e.SegurancaLogEnvio)
                .WithRequired(e => e.AcaoMovimentoDocumento)
                .HasForeignKey(e => e.idAcaoMovimentoDocumento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AcaoParteTipo>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<AcaoParteTipo>()
                .HasMany(e => e.AcaoParte)
                .WithRequired(e => e.AcaoParteTipo)
                .HasForeignKey(e => e.idAcaoParteTipo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Assunto>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Assunto>()
                .HasMany(e => e.Acao)
                .WithRequired(e => e.Assunto)
                .HasForeignKey(e => e.idAssunto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Assunto>()
                .HasMany(e => e.AcaoMovimento)
                .WithRequired(e => e.Assunto)
                .HasForeignKey(e => e.idAssunto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Classe>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Classe>()
                .HasMany(e => e.Acao)
                .WithRequired(e => e.Classe)
                .HasForeignKey(e => e.idClasse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Classe>()
                .HasMany(e => e.AcaoMovimento)
                .WithRequired(e => e.Classe)
                .HasForeignKey(e => e.idClasse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Movimento>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Movimento>()
                .HasMany(e => e.Acao)
                .WithOptional(e => e.Movimento)
                .HasForeignKey(e => e.idMovimento);

            modelBuilder.Entity<Movimento>()
                .HasMany(e => e.AcaoMovimento)
                .WithOptional(e => e.Movimento)
                .HasForeignKey(e => e.idMovimento);

            modelBuilder.Entity<Notificacao>()
                .Property(e => e.idUsuario)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Notificacao>()
                .Property(e => e.titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Notificacao>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .HasMany(e => e.AcaoParte)
                .WithRequired(e => e.Pessoa)
                .HasForeignKey(e => e.idPessoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rito>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Rito>()
                .HasMany(e => e.Acao)
                .WithRequired(e => e.Rito)
                .HasForeignKey(e => e.idRito)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rito>()
                .HasMany(e => e.AcaoMovimento)
                .WithRequired(e => e.Rito)
                .HasForeignKey(e => e.idRito)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SegurancaLogEnvio>()
                .Property(e => e.idUsuario)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SegurancaUsuario>()
                .Property(e => e.id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SegurancaUsuario>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<SegurancaUsuario>()
                .Property(e => e.senha)
                .IsUnicode(false);

            modelBuilder.Entity<SegurancaUsuario>()
                .HasMany(e => e.Notificacao)
                .WithRequired(e => e.SegurancaUsuario)
                .HasForeignKey(e => e.idUsuario);

            modelBuilder.Entity<SegurancaUsuario>()
                .HasMany(e => e.SegurancaLogEnvio)
                .WithRequired(e => e.SegurancaUsuario)
                .HasForeignKey(e => e.idUsuario)
                .WillCascadeOnDelete(false);
        }
    }
}
