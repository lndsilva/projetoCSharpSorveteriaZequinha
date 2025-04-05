using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SorveteriaZequinha
{
    public partial class frmFuncionarios : Form
    {
        public frmFuncionarios()
        {
            InitializeComponent();
            //executando o método desabilitar campos
            desabilitarCampos();
        }

        private void frmFuncionarios_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal abrir = new frmMenuPrincipal();
            abrir.Show();
            this.Hide();

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            frmPesquisarFuncionarios abrir = new frmPesquisarFuncionarios();
            abrir.Show();
            this.Hide();
        }
        //desabilitando os componentes
        public void desabilitarCampos()
        {
            txtNome.Enabled = false;
            txtCidade.Enabled = false;
            txtComplemento.Enabled = false;
            txtEmail.Enabled = false;
            txtLogradouro.Enabled = false;
            txtNumero.Enabled = false;
            mskCEP.Enabled = false;
            mskCPF.Enabled = false;
            mskTelefone.Enabled = false;
            cbbEstado.Enabled = false;
            cbbFuncao.Enabled = false;
            cbbUF.Enabled = false;
            dtpDataNascimento.Enabled = false;

            btnCadastrar.Enabled = false;
            btnExcluir.Enabled = false;
            btnAlterar.Enabled = false;
            btnLimpar.Enabled = false;

        }

        //habilitando os componentes
        public void habilitarCampos()
        {
            txtNome.Enabled = true;
            txtCidade.Enabled = true;
            txtComplemento.Enabled = true;
            txtEmail.Enabled = true;
            txtLogradouro.Enabled = true;
            txtNumero.Enabled = true;
            mskCEP.Enabled = true;
            mskCPF.Enabled = true;
            mskTelefone.Enabled = true;
            cbbEstado.Enabled = true;
            cbbFuncao.Enabled = true;
            cbbUF.Enabled = true;
            dtpDataNascimento.Enabled = true;

            btnCadastrar.Enabled = true;
            btnExcluir.Enabled = false;
            btnAlterar.Enabled = false;
            btnLimpar.Enabled = true;

            btnNovo.Enabled = false;
            txtNome.Focus();

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitarCampos();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Equals("")
                || txtEmail.Text.Equals("")
                || mskCPF.Text.Equals("   .   .   -")
                || cbbFuncao.Text.Equals("")
                || mskTelefone.Text.Equals("     -")
                || mskCEP.Text.Equals("     -")
                || txtLogradouro.Text.Equals("")
                || txtNumero.Text.Equals("")
                || txtCidade.Text.Equals("")
                || cbbEstado.Text.Equals("")
                || cbbUF.Text.Equals("")
                || txtComplemento.Text.Equals(""))
            {
                MessageBox.Show("Favor inserir valores.");
            }
            else
            {
                MessageBox.Show("Cadastrado com sucesso!!!");
                desabilitarCampos();
                
            }
        }
    }
}
