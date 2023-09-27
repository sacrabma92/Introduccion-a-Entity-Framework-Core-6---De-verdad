﻿// <auto-generated />
using System;
using EFCorePeliculas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;

#nullable disable

namespace EFCorePeliculas.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EFCorePeliculas.Entidades.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Biografia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaNacimiento")
                        .HasColumnType("date");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Actores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Biografia = "Thomas Stanley Holland (Kingston upon Thames, Londres; 1 de junio de 1996), conocido simplemente como Tom Holland, es un actor, actor de voz y bailarín británico.",
                            FechaNacimiento = new DateTime(1996, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Tom Holland"
                        },
                        new
                        {
                            Id = 2,
                            Biografia = "Samuel Leroy Jackson (Washington D. C., 21 de diciembre de 1948), conocido como Samuel L. Jackson, es un actor y productor de cine, televisión y teatro estadounidense. Ha sido candidato al premio Óscar, a los Globos de Oro y al Premio del Sindicato de Actores, así como ganador de un BAFTA al mejor actor de reparto.",
                            FechaNacimiento = new DateTime(1948, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Samuel L. Jackson"
                        },
                        new
                        {
                            Id = 3,
                            Biografia = "Robert John Downey Jr. (Nueva York, 4 de abril de 1965) es un actor, actor de voz, productor y cantante estadounidense. Inició su carrera como actor a temprana edad apareciendo en varios filmes dirigidos por su padre, Robert Downey Sr., y en su infancia estudió actuación en varias academias de Nueva York.",
                            FechaNacimiento = new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Robert Downey Jr."
                        },
                        new
                        {
                            Id = 4,
                            FechaNacimiento = new DateTime(1981, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Chris Evans"
                        },
                        new
                        {
                            Id = 5,
                            FechaNacimiento = new DateTime(1972, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Dwayne Johnson"
                        },
                        new
                        {
                            Id = 6,
                            FechaNacimiento = new DateTime(2000, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Auli'i Cravalho"
                        },
                        new
                        {
                            Id = 7,
                            FechaNacimiento = new DateTime(1984, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Scarlett Johansson"
                        },
                        new
                        {
                            Id = 8,
                            FechaNacimiento = new DateTime(1964, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Keanu Reeves"
                        });
                });

            modelBuilder.Entity("EFCorePeliculas.Entidades.Cine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<Point>("Ubicacion")
                        .HasColumnType("geography");

                    b.HasKey("Id");

                    b.ToTable("Cines");

                    b.HasData(
                        new
                        {
                            Id = 4,
                            Nombre = "Acropolis",
                            Ubicacion = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.939248 18.469649)")
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Sambil",
                            Ubicacion = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.911582 18.482455)")
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "Megacentro",
                            Ubicacion = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.856309 18.506662)")
                        },
                        new
                        {
                            Id = 1,
                            Nombre = "Agora Mall",
                            Ubicacion = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.9388777 18.4839233)")
                        });
                });

            modelBuilder.Entity("EFCorePeliculas.Entidades.CineDetalle", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("CodigoDeEtica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Historia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Misiones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Valores")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cines", (string)null);
                });

            modelBuilder.Entity("EFCorePeliculas.Entidades.CineOferta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CineId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("date");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("date");

                    b.Property<decimal>("PorcentajeDescuento")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.HasIndex("CineId")
                        .IsUnique();

                    b.ToTable("CinesOfertas");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            CineId = 4,
                            FechaFin = new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Local),
                            FechaInicio = new DateTime(2023, 9, 26, 0, 0, 0, 0, DateTimeKind.Local),
                            PorcentajeDescuento = 15m
                        },
                        new
                        {
                            Id = 1,
                            CineId = 1,
                            FechaFin = new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Local),
                            FechaInicio = new DateTime(2023, 9, 26, 0, 0, 0, 0, DateTimeKind.Local),
                            PorcentajeDescuento = 10m
                        });
                });

            modelBuilder.Entity("EFCorePeliculas.Entidades.Genero", b =>
                {
                    b.Property<int>("Identificador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Identificador"));

                    b.Property<bool>("EstaBorrado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Identificador");

                    b.HasIndex("Nombre")
                        .IsUnique()
                        .HasFilter("EstaBorrado = 'false'");

                    b.ToTable("Generos");

                    b.HasData(
                        new
                        {
                            Identificador = 1,
                            EstaBorrado = false,
                            Nombre = "Acción"
                        },
                        new
                        {
                            Identificador = 2,
                            EstaBorrado = false,
                            Nombre = "Animación"
                        },
                        new
                        {
                            Identificador = 3,
                            EstaBorrado = false,
                            Nombre = "Comedia"
                        },
                        new
                        {
                            Identificador = 4,
                            EstaBorrado = false,
                            Nombre = "Ciencia ficción"
                        },
                        new
                        {
                            Identificador = 5,
                            EstaBorrado = false,
                            Nombre = "Drama"
                        });
                });

            modelBuilder.Entity("EFCorePeliculas.Entidades.Log", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Mensaje")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("EFCorePeliculas.Entidades.Mensaje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contenido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmisorId")
                        .HasColumnType("int");

                    b.Property<int>("ReceptorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmisorId");

                    b.HasIndex("ReceptorId");

                    b.ToTable("Mensajes");
                });

            modelBuilder.Entity("EFCorePeliculas.Entidades.Pelicula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("EnCartelera")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaEstreno")
                        .HasColumnType("date");

                    b.Property<string>("PosterURL")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Peliculas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EnCartelera = false,
                            FechaEstreno = new DateTime(2012, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PosterURL = "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg",
                            Titulo = "Avengers"
                        },
                        new
                        {
                            Id = 2,
                            EnCartelera = false,
                            FechaEstreno = new DateTime(2017, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PosterURL = "https://upload.wikimedia.org/wikipedia/en/9/98/Coco_%282017_film%29_poster.jpg",
                            Titulo = "Coco"
                        },
                        new
                        {
                            Id = 3,
                            EnCartelera = false,
                            FechaEstreno = new DateTime(2021, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PosterURL = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg",
                            Titulo = "Spider-Man: No way home"
                        },
                        new
                        {
                            Id = 4,
                            EnCartelera = false,
                            FechaEstreno = new DateTime(2019, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PosterURL = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg",
                            Titulo = "Spider-Man: Far From Home"
                        },
                        new
                        {
                            Id = 5,
                            EnCartelera = true,
                            FechaEstreno = new DateTime(2100, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PosterURL = "https://upload.wikimedia.org/wikipedia/en/5/50/The_Matrix_Resurrections.jpg",
                            Titulo = "The Matrix Resurrections"
                        });
                });

            modelBuilder.Entity("EFCorePeliculas.Entidades.PeliculaActor", b =>
                {
                    b.Property<int>("PeliculaId")
                        .HasColumnType("int");

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<int>("Orden")
                        .HasColumnType("int");

                    b.Property<string>("Personaje")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("PeliculaId", "ActorId");

                    b.HasIndex("ActorId");

                    b.ToTable("PeliculasActores");

                    b.HasData(
                        new
                        {
                            PeliculaId = 4,
                            ActorId = 2,
                            Orden = 2,
                            Personaje = "Samuel L. Jackson"
                        },
                        new
                        {
                            PeliculaId = 4,
                            ActorId = 1,
                            Orden = 1,
                            Personaje = "Peter Parker"
                        },
                        new
                        {
                            PeliculaId = 3,
                            ActorId = 1,
                            Orden = 1,
                            Personaje = "Peter Parker"
                        },
                        new
                        {
                            PeliculaId = 1,
                            ActorId = 3,
                            Orden = 2,
                            Personaje = "Iron Man"
                        },
                        new
                        {
                            PeliculaId = 1,
                            ActorId = 7,
                            Orden = 3,
                            Personaje = "Black Widow"
                        },
                        new
                        {
                            PeliculaId = 1,
                            ActorId = 4,
                            Orden = 1,
                            Personaje = "Capitán América"
                        },
                        new
                        {
                            PeliculaId = 5,
                            ActorId = 8,
                            Orden = 1,
                            Personaje = "Neo"
                        });
                });

            modelBuilder.Entity("EFCorePeliculas.Entidades.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("EFCorePeliculas.Entidades.SalaDeCine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CineId")
                        .HasColumnType("int");

                    b.Property<string>("Moneda")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasPrecision(9, 2)
                        .HasColumnType("decimal(9,2)");

                    b.Property<string>("TipoSalaDeCine")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("DosDimensiones");

                    b.HasKey("Id");

                    b.HasIndex("CineId");

                    b.ToTable("SalasDeCines");

                    b.HasData(
                        new
                        {
                            Id = 5,
                            CineId = 3,
                            Moneda = "",
                            Precio = 250m,
                            TipoSalaDeCine = "DosDimensiones"
                        },
                        new
                        {
                            Id = 6,
                            CineId = 3,
                            Moneda = "",
                            Precio = 330m,
                            TipoSalaDeCine = "TresDimensiones"
                        },
                        new
                        {
                            Id = 7,
                            CineId = 3,
                            Moneda = "",
                            Precio = 450m,
                            TipoSalaDeCine = "CXC"
                        },
                        new
                        {
                            Id = 8,
                            CineId = 4,
                            Moneda = "",
                            Precio = 250m,
                            TipoSalaDeCine = "DosDimensiones"
                        },
                        new
                        {
                            Id = 1,
                            CineId = 1,
                            Moneda = "",
                            Precio = 220m,
                            TipoSalaDeCine = "DosDimensiones"
                        },
                        new
                        {
                            Id = 2,
                            CineId = 1,
                            Moneda = "",
                            Precio = 320m,
                            TipoSalaDeCine = "TresDimensiones"
                        },
                        new
                        {
                            Id = 3,
                            CineId = 2,
                            Moneda = "",
                            Precio = 200m,
                            TipoSalaDeCine = "DosDimensiones"
                        },
                        new
                        {
                            Id = 4,
                            CineId = 2,
                            Moneda = "",
                            Precio = 290m,
                            TipoSalaDeCine = "TresDimensiones"
                        });
                });

            modelBuilder.Entity("EFCorePeliculas.Entidades.SinLLaves.CineSinUbicacion", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable((string)null);

                    b.ToView(null, (string)null);

                    b.ToSqlQuery("Select Id, Nombre FROM Cines");
                });

            modelBuilder.Entity("EFCorePeliculas.Entidades.SinLLaves.PeliculaConConteos", b =>
                {
                    b.Property<int>("CantidadActores")
                        .HasColumnType("int");

                    b.Property<int>("CantidadCines")
                        .HasColumnType("int");

                    b.Property<int>("CantidadGeneros")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable((string)null);

                    b.ToView("PeliculasConteo", (string)null);
                });

            modelBuilder.Entity("GeneroPelicula", b =>
                {
                    b.Property<int>("GenerosIdentificador")
                        .HasColumnType("int");

                    b.Property<int>("PeliculasId")
                        .HasColumnType("int");

                    b.HasKey("GenerosIdentificador", "PeliculasId");

                    b.HasIndex("PeliculasId");

                    b.ToTable("GeneroPelicula");

                    b.HasData(
                        new
                        {
                            GenerosIdentificador = 1,
                            PeliculasId = 1
                        },
                        new
                        {
                            GenerosIdentificador = 4,
                            PeliculasId = 1
                        },
                        new
                        {
                            GenerosIdentificador = 2,
                            PeliculasId = 2
                        },
                        new
                        {
                            GenerosIdentificador = 4,
                            PeliculasId = 3
                        },
                        new
                        {
                            GenerosIdentificador = 1,
                            PeliculasId = 3
                        },
                        new
                        {
                            GenerosIdentificador = 3,
                            PeliculasId = 3
                        },
                        new
                        {
                            GenerosIdentificador = 4,
                            PeliculasId = 4
                        },
                        new
                        {
                            GenerosIdentificador = 1,
                            PeliculasId = 4
                        },
                        new
                        {
                            GenerosIdentificador = 3,
                            PeliculasId = 4
                        },
                        new
                        {
                            GenerosIdentificador = 4,
                            PeliculasId = 5
                        },
                        new
                        {
                            GenerosIdentificador = 1,
                            PeliculasId = 5
                        },
                        new
                        {
                            GenerosIdentificador = 5,
                            PeliculasId = 5
                        });
                });

            modelBuilder.Entity("PeliculaSalaDeCine", b =>
                {
                    b.Property<int>("PeliculasId")
                        .HasColumnType("int");

                    b.Property<int>("SalasDeCineId")
                        .HasColumnType("int");

                    b.HasKey("PeliculasId", "SalasDeCineId");

                    b.HasIndex("SalasDeCineId");

                    b.ToTable("PeliculaSalaDeCine");

                    b.HasData(
                        new
                        {
                            PeliculasId = 5,
                            SalasDeCineId = 3
                        },
                        new
                        {
                            PeliculasId = 5,
                            SalasDeCineId = 4
                        },
                        new
                        {
                            PeliculasId = 5,
                            SalasDeCineId = 1
                        },
                        new
                        {
                            PeliculasId = 5,
                            SalasDeCineId = 2
                        },
                        new
                        {
                            PeliculasId = 5,
                            SalasDeCineId = 5
                        },
                        new
                        {
                            PeliculasId = 5,
                            SalasDeCineId = 6
                        },
                        new
                        {
                            PeliculasId = 5,
                            SalasDeCineId = 7
                        });
                });

            modelBuilder.Entity("EFCorePeliculas.Entidades.Actor", b =>
                {
                    b.OwnsOne("EFCorePeliculas.Entidades.Direccion", "BillingAddress", b1 =>
                        {
                            b1.Property<int>("ActorId")
                                .HasColumnType("int");

                            b1.Property<string>("Calle")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Pais")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Provincia")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ActorId");

                            b1.ToTable("Actores");

                            b1.WithOwner()
                                .HasForeignKey("ActorId");
                        });

                    b.OwnsOne("EFCorePeliculas.Entidades.Direccion", "DireccionHogar", b1 =>
                        {
                            b1.Property<int>("ActorId")
                                .HasColumnType("int");

                            b1.Property<string>("Calle")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Calle");

                            b1.Property<string>("Pais")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Pais");

                            b1.Property<string>("Provincia")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Provincia");

                            b1.HasKey("ActorId");

                            b1.ToTable("Actores");

                            b1.WithOwner()
                                .HasForeignKey("ActorId");
                        });

                    b.Navigation("BillingAddress");

                    b.Navigation("DireccionHogar");
                });

            modelBuilder.Entity("EFCorePeliculas.Entidades.Cine", b =>
                {
                    b.OwnsOne("EFCorePeliculas.Entidades.Direccion", "Direccion", b1 =>
                        {
                            b1.Property<int>("CineId")
                                .HasColumnType("int");

                            b1.Property<string>("Calle")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Calle");

                            b1.Property<string>("Pais")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Pais");

                            b1.Property<string>("Provincia")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Provincia");

                            b1.HasKey("CineId");

                            b1.ToTable("Cines");

                            b1.WithOwner()
                                .HasForeignKey("CineId");
                        });

                    b.Navigation("Direccion");
                });

            modelBuilder.Entity("EFCorePeliculas.Entidades.CineDetalle", b =>
                {
                    b.HasOne("EFCorePeliculas.Entidades.Cine", "Cine")
                        .WithOne("CineDetalle")
                        .HasForeignKey("EFCorePeliculas.Entidades.CineDetalle", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cine");
                });

            modelBuilder.Entity("EFCorePeliculas.Entidades.CineOferta", b =>
                {
                    b.HasOne("EFCorePeliculas.Entidades.Cine", null)
                        .WithOne("CineOferta")
                        .HasForeignKey("EFCorePeliculas.Entidades.CineOferta", "CineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCorePeliculas.Entidades.Mensaje", b =>
                {
                    b.HasOne("EFCorePeliculas.Entidades.Persona", "Emisor")
                        .WithMany("MensajesEnviados")
                        .HasForeignKey("EmisorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCorePeliculas.Entidades.Persona", "Receptor")
                        .WithMany("MensajesRecibidos")
                        .HasForeignKey("ReceptorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Emisor");

                    b.Navigation("Receptor");
                });

            modelBuilder.Entity("EFCorePeliculas.Entidades.PeliculaActor", b =>
                {
                    b.HasOne("EFCorePeliculas.Entidades.Actor", "Actor")
                        .WithMany("PeliculasActores")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCorePeliculas.Entidades.Pelicula", "Pelicula")
                        .WithMany("PeliculasActores")
                        .HasForeignKey("PeliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Pelicula");
                });

            modelBuilder.Entity("EFCorePeliculas.Entidades.SalaDeCine", b =>
                {
                    b.HasOne("EFCorePeliculas.Entidades.Cine", "Cine")
                        .WithMany("SalaDeCine")
                        .HasForeignKey("CineId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cine");
                });

            modelBuilder.Entity("GeneroPelicula", b =>
                {
                    b.HasOne("EFCorePeliculas.Entidades.Genero", null)
                        .WithMany()
                        .HasForeignKey("GenerosIdentificador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCorePeliculas.Entidades.Pelicula", null)
                        .WithMany()
                        .HasForeignKey("PeliculasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PeliculaSalaDeCine", b =>
                {
                    b.HasOne("EFCorePeliculas.Entidades.Pelicula", null)
                        .WithMany()
                        .HasForeignKey("PeliculasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCorePeliculas.Entidades.SalaDeCine", null)
                        .WithMany()
                        .HasForeignKey("SalasDeCineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCorePeliculas.Entidades.Actor", b =>
                {
                    b.Navigation("PeliculasActores");
                });

            modelBuilder.Entity("EFCorePeliculas.Entidades.Cine", b =>
                {
                    b.Navigation("CineDetalle");

                    b.Navigation("CineOferta");

                    b.Navigation("SalaDeCine");
                });

            modelBuilder.Entity("EFCorePeliculas.Entidades.Pelicula", b =>
                {
                    b.Navigation("PeliculasActores");
                });

            modelBuilder.Entity("EFCorePeliculas.Entidades.Persona", b =>
                {
                    b.Navigation("MensajesEnviados");

                    b.Navigation("MensajesRecibidos");
                });
#pragma warning restore 612, 618
        }
    }
}
