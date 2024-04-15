using Microsoft.VisualBasic.Logging;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // �������� ���������� ���������� ����������� ��� ������������� �����
            textBox1.Text = Properties.Settings.Default.LastEnteredSentence;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sentence = textBox1.Text;
            double letterPercents = Logic.CalculateLetterPercents(sentence);

            // ����� ���������� � ����� ������� ����� �������
            resultLabel.Text = $"���� ���� � �����������: {letterPercents:F2}%";

            // ���������� ����������� � ���������
            Properties.Settings.Default.LastEnteredSentence = sentence;
            Properties.Settings.Default.Save();
        }

        public class Logic // �����, ����������� ������ ���������
        {
            public static double CalculateLetterPercents(string sentence) // ������� ��� ����������� ���� ���� � �����������
            {
                int letterCount = 0; // ���������� ��� �������� ���������� ����
                int totalCharacters = 0; // ���������� ��� �������� ���������� ���� ��������

                // ������ �� ������� ������� � �����������
                foreach (char character in sentence)
                {
                    if (char.IsLetter(character)) // ���� ������ �������� ������
                    {
                        letterCount++; // ����������� ������� ����
                    }
                    totalCharacters++; // ����������� ������� ���� ��������
                }
                // �������� �� ������ ������ � �����������
                if (!(totalCharacters > 0))
                {
                    return 0; // ���������� 0 � ������� ��������� � ���� ���� 0,00%
                }
                // ���������� ���� ���� � ����������� � �������������� � ��������
                double letterPercents = (double)letterCount / totalCharacters * 100;
                return letterPercents; // ���������� ���� ���� � ���������
            }
        }

    }
}