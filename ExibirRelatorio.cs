using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Relatorios_RDLC.DataSet1TableAdapters;

namespace Relatorios_RDLC
{
    public partial class ExibirRelatorio : Form
    {
        public ExibirRelatorio()
        {
            InitializeComponent();

            //this.reportViewer.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;
        }

        //private void LocalReport_SubreportProcessing(object sender, Microsoft.Reporting.WinForms.SubreportProcessingEventArgs e)
        //{

        //    //Parametros que são enviados para o reportviewer pela aplicação.
        //    //DateTime dataInicial = new DateTime(2021, 10, 01, 00, 00, 00, 000);
        //    //DateTime dataFinal = new DateTime(2021, 10, 31, 23, 59, 59, 998);
        //    //string strPeriodo = dataInicial.ToShortDateString() + " - " + dataFinal.ToShortDateString();

        //    //Criação dos table adapters para pegar as informações para preencher os data tables.
        //    PR_REL_FCH001TableAdapter adpDados = new PR_REL_FCH001TableAdapter();

        //    //Data tables para retornar informações para o reportviewer
        //    DataTable dtDados = adpDados.GetData(1, 377, 1);

        //    //Passando os parametros
        //    //reportViewer.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("periodo", strPeriodo));

        //    //Passando os dados dos datatables para o report
        //    e.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("FichaAtendimento", dtDados));
        //}

        private void ExibirRelatorio_Load(object sender, EventArgs e)
        {

            //Parametros que são enviados para o reportviewer pela aplicação.
            DateTime dataInicial = new DateTime(2023, 08, 01, 00, 00, 00, 000);
            DateTime dataFinal = new DateTime(2023, 09, 01, 23, 59, 59, 997);
            string strPeriodo = dataInicial.ToShortDateString() + " - " + dataFinal.ToShortDateString();

            //Criação dos table adapters para pegar as informações para preencher os data tables.
            //cad_LOCALATENDIMENTOTableAdapter adpCabecalho = new cad_LOCALATENDIMENTOTableAdapter();
            PR_REL_CABECALHOTableAdapter adpCabecalho = new PR_REL_CABECALHOTableAdapter();
            PR_REL_EST036TableAdapter adpDados = new PR_REL_EST036TableAdapter();

            //Data tables para retornar informações para o reportviewer
            DataTable dtCabecalho = adpCabecalho.GetData(1, 1, null, null, null, null, null, null, null, null, null, null);
            DataTable dtDados = adpDados.GetData(dataInicial, dataFinal,null, null, null, null, null, null, null, null, null, null);

            //Imagens integradas
            reportViewer.LocalReport.EnableExternalImages = true;

            //Passando os parametros
            reportViewer.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("periodo", strPeriodo));
            //reportViewer.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("usuarioWeb", "123456789"));

            //Passando os dados dos datatables para o report
            //reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("FichaAtendimento", dtDados));
            //reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CadLocalAtendimento", dtCabecalho));
            //reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("FINM074", dtDados));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Cabecalho", dtCabecalho));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Dados", dtDados));

            reportViewer.RefreshReport();
        }
    }
}