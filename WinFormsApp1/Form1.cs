namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            int lastValue = Properties.Settings.Default.LastEnteredValue;
            if (lastValue >= 1 && lastValue <= 9999)
            {
                textBox1.Text = lastValue.ToString();
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            int n = 0;

            try
            {
                // ������� ������������� ��������� �������� � ����� � �������� �� �������� �� 1 �� 9999
                if (int.TryParse(textBox1.Text, out n) && n >= 1 && n <= 9999)
                {
                    // ����� ������ FormatCost � ����� ����������
                    labelResult.Text = Logic.FormatCost(n);
                    // ���������� �������� � ����������
                    Properties.Settings.Default.LastEnteredValue = n;
                    Properties.Settings.Default.Save();

                }
                else
                {
                    // ��������� �� ������, ���� ���� �������
                    labelResult.Text = "������� ����� �� 1 �� 9999.";
                }
            }
            catch (Exception ex)
            {
                return; // ��������� ���������� �����, ���� ����� �����-�� ������
            }
        }

    }

    public class Logic
    {
        public static string GetRublesWord(int rubles) // ��� ����������� ����������� ��������� ����� "�����" � ����������� �� ����������
        {
            // ��� ���� �����, ������������ �� 1, ����� ����� "11"
            if (rubles == 1 || (rubles % 10 == 1 && rubles != 11))
            {
                return "�����";
            }
            // ��� ���� �����, ������������ �� 2, 3, 4, ����� ����� �� "12" �� "14"
            else if ((rubles >= 2 && rubles <= 4) || ((rubles % 10 >= 2 && rubles % 10 <= 4) && (rubles < 10 || rubles > 20)))
            {
                return "�����";
            }
            // ��� ���� ��������� �����
            else
            {
                return "������";
            }
        }

        public static string GetKopecksWord(int kopecks) // ������� ��� ����������� ����������� ��������� ����� "�������" � ����������� �� ����������
        {
            // ��� ���� �����, ������������ �� 1, ����� ����� "11"
            if (kopecks == 1 || (kopecks % 10 == 1 && kopecks != 11))
            {
                return "�������";
            }
            // ��� ���� �����, ������������ �� 2, 3, 4, ����� ����� �� "12" �� "14"
            else if ((kopecks >= 2 && kopecks <= 4) || ((kopecks % 10 >= 2 && kopecks % 10 <= 4) && (kopecks < 10 || kopecks > 20)))
            {
                return "�������";
            }
            // ��� ���� ��������� �����
            else
            {
                return "������";
            }
        }

        public static (int, string, int, string) CalculateCost(int n) // ������� ��� ���������� ��������� �� ����� � �������
        {
            int rubles = n / 100; // ����������� ���������� ������
            int kopecks = n % 100; // ����������� ���������� ������
            string rublesWord = GetRublesWord(rubles); // ��������� � ������� GetRublesWord, ����� ���������� ��������� ����� "�����"
            string kopecksWord = GetKopecksWord(kopecks); // ��������� � ������� GetKopecksWord, ����� ���������� ��������� ����� "�������"
            return (rubles, rublesWord, kopecks, kopecksWord); // ���������� ���������� �������� � FormatCost
        }

        public static string FormatCost(int n) // ������� ��� ���������������� ������ ���������
        {
            var (rubles, rublesWord, kopecks, kopecksWord) = CalculateCost(n); // ����������� ������ � ������� CalculateCost

            if (kopecks == 0) // ���� ��� ������, �� ������� ������ �����
            {
                return $"���������: {rubles} {rublesWord} �����";
            }
            else // ���� ������� ����, �� ������� � ����� � �������
            {
                return $"���������: {rubles} {rublesWord} {kopecks} {kopecksWord}";
            }
        }
    }
}