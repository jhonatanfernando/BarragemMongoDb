using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BarragemMongoDb.Domain.Entities;

public class Barragem
{
    [BsonId] // Explicitly marks this property as the `_id` field
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public long CodigoSNISB { get; set; }
    public required string NomeDaBarragem { get; set; }
    public string? NomeSecundario { get; set; }
    public string? UsoPrincipal { get; set; }
    public string? UF { get; set; }
    public string? Municipio { get; set; }
    public string? CategoriaDeRisco { get; set; }
    public string? DanoPotencialAssociado { get; set; }
    public string? NomeDoEmpreendedor { get; set; }
    public string? TipoEmpreendedor { get; set; }
    public string? OrgaoFiscalizador { get; set; }
    public string? CodigoBarragemFiscalizador { get; set; }
    public string? ReguladoPelaPNSB { get; set; }
    public string? NumeroDaAutorizacao { get; set; }
    public string? PossuiPAE { get; set; }
    public string? PossuiPlanoDeSeguranca { get; set; }
    public string? PossuiRevisaoPeriodica { get; set; }
    public DateTime? DataDaUltimaFiscalizacao { get; set; }
    public string? BarragemAutuada { get; set; }
    public double? AlturaFundacaoM { get; set; }
    public double? AlturaTerrenoM { get; set; }
    public double? CapacidadeHm3 { get; set; }
    public double? ComprimentoCoroamentoM { get; set; }
    public double? AreaDoReservatorioHa { get; set; }
    public string? TipoDeMaterial { get; set; }
    public string? UsoComplementar { get; set; }
    public string? Classe { get; set; }
    public string? ClasseDeResiduo { get; set; }
    public string? CursoDAguaBarrado { get; set; }
    public string? NomeCursoDAgua { get; set; }
    public string? RegiaoHidrografica { get; set; }
    public string? UnidadeDeGestao { get; set; }
    public string? Dominio { get; set; }
    public DateTime? DataDaUltimaInspecao { get; set; }
    public string? TipoDaUltimaInspecao { get; set; }
    public string? NivelDePerigoGlobal { get; set; }
    public string? PossuiEclusa { get; set; }
    public string? FaseDaVida { get; set; }
    public DateTime? FaseDaVidaDataInicio { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string? Completude { get; set; }
    public DateTime? DataCadastro { get; set; }
    public bool Sincronizado { get; set; }
}
