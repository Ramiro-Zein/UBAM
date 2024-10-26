using System.ComponentModel.DataAnnotations;

namespace API_UBAM.Models;

public class Carrera
{
    [Key] public Guid Id_Carrera { get; set; }

    [Required] public NombreCarrera Nombre_Carrera { get; set; }

    // Relación uno a muchos con Alumno
    public ICollection<Alumno> Alumnos { get; set; }

    public enum NombreCarrera
    {
        [Display(Name = "Administración de Empresas")]
        AdministracionDeEmpresas,

        [Display(Name = "Administración de Empresas Turísticas")]
        AdministracionDeEmpresasTuristicas,

        [Display(Name = "Relaciones Internacionales")]
        RelacionesInternacionales,

        [Display(Name = "Contaduría Pública y Finanzas")]
        ContaduriaPublicaYFinanzas,

        [Display(Name = "Derecho")] Derecho,

        [Display(Name = "Mercadotecnia y Publicidad")]
        MercadotecniaYPublicidad,

        [Display(Name = "Gastronomía")] Gastronomia,

        [Display(Name = "Periodismo y Ciencias de la Comunicación")]
        PeriodismoYCienciasDeLaComunicacion,

        [Display(Name = "Diseño de Modas")] DisenoDeModas,

        [Display(Name = "Pedagogía")] Pedagogia,

        [Display(Name = "Cultura Física y Educación del Deporte")]
        CulturaFisicaYEducacionDelDeporte,

        [Display(Name = "Idiomas (Inglés y Francés)")]
        IdiomasInglesYFrances,

        [Display(Name = "Psicología")] Psicologia,

        [Display(Name = "Diseño de Interiores")]
        DisenoDeInteriores,

        [Display(Name = "Diseño Gráfico")] DisenoGrafico,

        [Display(Name = "Ingeniería en Logística y Transporte")]
        IngenieriaEnLogisticaYTransporte,

        [Display(Name = "Ingeniero Arquitecto")]
        IngenieroArquitecto,

        [Display(Name = "Informática Administrativa y Fiscal")]
        InformaticaAdministrativaYFiscal,

        [Display(Name = "Ingeniería en Sistemas Computacionales")]
        IngenieriaEnSistemasComputacionales,

        [Display(Name = "Ingeniería Mecánica Automotriz")]
        IngenieriaMecanicaAutomotriz
    }
}