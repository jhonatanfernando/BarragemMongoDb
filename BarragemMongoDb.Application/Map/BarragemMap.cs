using CsvHelper.Configuration;

namespace BarragemMongoDb.Application.Map;

public sealed class BarragemMap : ClassMap<Domain.Entities.Barragem>
{
    public BarragemMap()
    {
        // Map CSV header names to the properties of the Barragem class
        Map(m => m.CodigoSNISB).Name("Código_SNISB ");
        Map(m => m.NomeDaBarragem).Name("Nome_da_Barragem");
        Map(m => m.NomeSecundario).Name("Nome_Secundário ");
        Map(m => m.UsoPrincipal).Name("Uso_Principal");
        Map(m => m.UF).Name("UF");
        Map(m => m.Municipio).Name("Município ");
        Map(m => m.CategoriaDeRisco).Name("Categoria_de_Risco");
        Map(m => m.DanoPotencialAssociado).Name("Dano_Potencial_Associado");
        Map(m => m.NomeDoEmpreendedor).Name("Nome_do_Empreendedor");
        Map(m => m.TipoEmpreendedor).Name("Tipo_Empreendedor");
        Map(m => m.OrgaoFiscalizador).Name("Órgão_Fiscalizador  ");
        Map(m => m.CodigoBarragemFiscalizador).Name("Código_Barragem_Fiscalizador ");
        Map(m => m.ReguladoPelaPNSB).Name("Regulada_pela_PNSB");
        Map(m => m.NumeroDaAutorizacao).Name("Número_da_Autorização   ");
        Map(m => m.PossuiPAE).Name("Possui_PAE");
        Map(m => m.PossuiPlanoDeSeguranca).Name("Possui_Plano_de_Segurança ");
        Map(m => m.PossuiRevisaoPeriodica).Name("Possui_Revisão_Periódica  ");
        Map(m => m.DataDaUltimaFiscalizacao).Name("Data_da_Última_Fiscalização   ").TypeConverterOption.Format("dd-MM-yyyy");
        Map(m => m.BarragemAutuada).Name("Barragem_Autuada");
        Map(m => m.AlturaFundacaoM).Name("Altura_Fundação_m  ");
        Map(m => m.AlturaTerrenoM).Name("Altura_Terreno_m");
        Map(m => m.CapacidadeHm3).Name("Capacidade_hm³ ");
        Map(m => m.ComprimentoCoroamentoM).Name("Comprimento_Coroamento_m");
        Map(m => m.AreaDoReservatorioHa).Name("Area_do_Reservatorio_ha");
        Map(m => m.TipoDeMaterial).Name("Tipo_de_Material");
        Map(m => m.UsoComplementar).Name("Uso_Complementar");
        Map(m => m.Classe).Name("Classe");
        Map(m => m.ClasseDeResiduo).Name("Classe_de_Resíduo ");
        Map(m => m.CursoDAguaBarrado).Name("Curso_Dágua_Barrado ");
        Map(m => m.NomeCursoDAgua).Name("Nome_Curso_dágua ");
        Map(m => m.RegiaoHidrografica).Name("Região_Hidrográfica  ");
        Map(m => m.UnidadeDeGestao).Name("Unidade_de_Gestão ");
        Map(m => m.Dominio).Name("Domínio ");
        Map(m => m.DataDaUltimaInspecao).Name("Data_da_Última_Inspeção   ").TypeConverterOption.Format("dd-MM-yyyy");
        Map(m => m.TipoDaUltimaInspecao).Name("Tipo_da_Última_Inspeção   ");
        Map(m => m.NivelDePerigoGlobal).Name("Nível_de_Perigo_Global ");
        Map(m => m.PossuiEclusa).Name("Possui_Eclusa");
        Map(m => m.FaseDaVida).Name("Fase_da_Vida");
        Map(m => m.FaseDaVidaDataInicio).Name("Fase_da_Vida_Data_Inicio");
        Map(m => m.Latitude).Name("Latitude");
        Map(m => m.Longitude).Name("Longitude");
        Map(m => m.Completude).Name("Completude");
    }
}
