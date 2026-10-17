using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicativoSaude
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            bool alturaValida = double.TryParse(txtAltura.Text, out double altura);
            bool pesoValido = double.TryParse(txtPeso.Text, out double peso);
            double imc, aguaLitros, aguaCopos;

            if (alturaValida && pesoValido && altura > 0.59 && peso > 19 && peso < 650 && altura < 2.76)
            {
                labelAviso.Visible = false;
                altura = double.Parse(txtAltura.Text);
                peso = double.Parse(txtPeso.Text);
                imc = peso / (Math.Pow(altura, 2));
                txtResultadoIMC.Text = imc.ToString("F2");
                aguaLitros = peso * 0.035;
                aguaCopos = aguaLitros * 1000 / 240;
                txtAguaDia.Text = aguaLitros.ToString("F1");
                txtAguaCopo.Text = aguaCopos.ToString("F0");

                if (imc < 18.5)
                {
                    picContagem.Image = Properties.Resources.AbaixoDoPeso;
                    labelRelatorioIMC.Text = "Abaixo do peso (IMC menor que 18,5): Estar abaixo do peso recomendado pode indicar fragilidade no \nsistema imunológico, perda de massa muscular e maior suscetibilidade a infecções, fadiga ou deficiências \nnutricionais (como anemia). Nessa faixa, a prioridade para a saúde é garantir uma ingestão adequada de \nnutrientes essenciais e calorias de boa qualidade para fortalecer o organismo de forma equilibrada.";
                }
                else if (imc >= 18.5 && imc <= 24.9)
                {
                    picContagem.Image = Properties.Resources.PesoIdeal;
                    labelRelatorioIMC.Text = "Peso ideal ou adequado (IMC entre 18,5 e 24,9): Esta faixa reflete um equilíbrio saudável entre o peso \ncorporal e a altura, sendo associada ao menor risco de desenvolvimento de doenças crônicas como \nhipertensão e diabetes tipo 2. A manutenção desse estado requer a continuidade de hábitos de vida \nequilibrados, com alimentação variada e prática regular de atividades físicas para sustentar a disposição \ne o bem-estar geral.";
                }
                else if (imc >= 25 && imc <= 29.9)
                {
                    picContagem.Image = Properties.Resources.Sobrepeso;
                    labelRelatorioIMC.Text = "Sobrepeso (IMC entre 25,0 e 29,9): O sobrepeso sinaliza uma fase de atenção em que o corpo começa a \nacumular excesso de tecido adiposo, o que pode sobrecarregar gradualmente o sistema cardiovascular \ne as articulações. Embora muitas pessoas nessa faixa não apresentem sintomas imediatos, é um momento \npropício para adotar pequenos ajustes na rotina como reduzir alimentos ultraprocessados e aumentar \na movimentação diária para evitar a progressão para quadros mais complexos.";
                }
                else if (imc >= 30 && imc <= 34.9)
                {
                    picContagem.Image = Properties.Resources.ObesidadeGrau1;
                    labelRelatorioIMC.Text = "Obesidade Grau I (IMC entre 30,0 e 34,9): Nesse estágio, o acúmulo de gordura corporal passa a aumentar \nmoderadamente os riscos de alteração nos níveis de colesterol, glicose e pressão arterial, além de gerar \nmaior desgaste nas articulações dos joelhos e quadril. Os cuidados devem focar no reequilíbrio metabólico \npor meio de reeducação alimentar contínua e exercícios adaptados, visando à proteção cardiovascular e à \nmelhoria da qualidade de vida.";
                }
                else if (imc >= 35 && imc <= 39.9)
                {
                    picContagem.Image = Properties.Resources.ObesidadeGrau2;
                    labelRelatorioIMC.Text = "Obesidade Grau II / Severa (IMC entre 35,0 e 39,9): A obesidade severa eleva consideravelmente as \nchances de complicações de saúde, como apneia do sono, problemas hepáticos e hipertensão arterial \nde difícil controle. O acompanhamento médico e multiprofissional torna-se fundamental nessa etapa \npara traçar metas de redução de danos, prevenir agravamentos e restabelecer a capacidade funcional \ndo corpo de maneira segura.";
                }
                else
                {
                    picContagem.Image = Properties.Resources.ObesidadeGrau3;
                    labelRelatorioIMC.Text = "Obesidade Grau III / Mórbida (IMC igual ou superior a 40,0): Esta classificação representa um nível elevado \nde vulnerabilidade à saúde, com alto risco de eventos cardiovasculares e limitações na mobilidade diária. \nA intervenção para essa faixa exige cuidados integrados e especializados para controlar fatores \nmetabólicos graves, promovendo suporte contínuo para a recuperação do bem-estar e da longevidade.";
                }
            }
            else
            {
                System.Media.SystemSounds.Hand.Play();
                labelAviso.Visible = true;
                txtResultadoIMC.Clear();
                txtAguaDia.Clear();
                txtAguaCopo.Clear();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtAltura.Clear();
            txtPeso.Clear();
            txtAguaDia.Clear();
            txtAguaCopo.Clear();
            txtResultadoIMC.Clear();
            labelRelatorioIMC.Text = "Relatório IMC personalizado";
        }
    }
}
