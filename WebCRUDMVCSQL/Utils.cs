using ObraFacilApp.Models;

namespace ObraFacilApp
{
    public class Utils
    {
        public static decimal QtdOkFundacao(FundacaoModel? fundacaoExistente)
        {
            var contFundacaoOk = 0;

            if (fundacaoExistente?.AlicerceOK ?? false)
                contFundacaoOk++;

            if (fundacaoExistente?.VigaBaldrameOK ?? false)
                contFundacaoOk++;

            if (fundacaoExistente?.IpermeabilizacaoVigaBaldrameOK ?? false)
                contFundacaoOk++;

            if (fundacaoExistente?.QtdMicroOK ?? false)
                contFundacaoOk++;

            if (fundacaoExistente?.DataInicioFundacaoOK ?? false)
                contFundacaoOk++;

            if (fundacaoExistente?.DataConclusaoFundacaoOK ?? false)
                contFundacaoOk++;

            return (contFundacaoOk * 100) / 6;
        }

        public static decimal QtdOkAlvenaria(AlvenariaModel? alvenariaModel)
        {
            var contAlvenariaOk = 0;

            if (alvenariaModel?.MetrosDeParedeOK ?? false)
                contAlvenariaOk++;

            if (alvenariaModel?.QtdBlocosOk ?? false)
                contAlvenariaOk++;

            if (alvenariaModel?.QtdPilaresOk ?? false)
                contAlvenariaOk++;

            if (alvenariaModel?.DataInicioAlvenariaOk ?? false)
                contAlvenariaOk++;

            if (alvenariaModel?.DataConclusaoAlvenariaOk ?? false)
                contAlvenariaOk++;


            return (contAlvenariaOk * 100) / 5;
        }

        public static decimal QtdOkCobertura(CoberturaModel? cobertura)
        {
            var ret = 0;

            if (cobertura?.TamanhoCoberturaOK ?? false)
                ret++;

            //if (cobertura?.MetragemCubicaLageOk ?? false)
            //    ret++;

            //if (cobertura?.EspeEspessuraLajeOK ?? false)
            //    ret++;

            if (cobertura?.DataInicioCoberturaOK ?? false)
                ret++;

            if (cobertura?.DataConclusaoCoberturaOK ?? false)
                ret++;


            return (ret * 100) / 3;
        }

        public static decimal QtdOkEletrica(EletricaModel? eletrica)
        {
            var ret = 0;

            //if (eletrica?.LigacaoMonofasicaOk ?? false)
            //    ret++;

            //if (eletrica?.LigacaoTrifasicaOk ?? false)
            //    ret++;

            if (eletrica?.QtdDisjuntoresOk ?? false)
                ret++;

            if (eletrica?.QtdTomadasOk ?? false)
                ret++;

            if (eletrica?.QtdLampadasOk ?? false)
                ret++;

            if (eletrica?.DataInicioEletricaOk ?? false)
                ret++;

            if (eletrica?.DataConclusaoEletricaOk ?? false)
                ret++;


            return (ret * 100) / 5;
        }

        public static decimal QtdOkHidraulica(HidraulicaModel? hidraulica)
        {
            var ret = 0;

            if (hidraulica?.QtdTorneirasOK ?? false)
                ret++;

            if (hidraulica?.QtdRalosOK ?? false)
                ret++;

            if (hidraulica?.QtdRegistrosOk ?? false)
                ret++;

            if (hidraulica?.DataInicioHidraulicaOK ?? false)
                ret++;

            if (hidraulica?.DataConclusaoHidraulicaOK ?? false)
                ret++;

            if (hidraulica?.QtdCaixaGorduraOk ?? false)
                ret++;


            return (ret * 100) / 6;
        }
    }
}
