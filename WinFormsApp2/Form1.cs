using Microsoft.VisualBasic.Logging;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Загрузка последнего введенного предложения при инициализации формы
            textBox1.Text = Properties.Settings.Default.LastEnteredSentence;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sentence = textBox1.Text;
            double letterPercents = Logic.CalculateLetterPercents(sentence);

            // Вывод результата с двумя знаками после запятой
            resultLabel.Text = $"Доля букв в предложении: {letterPercents:F2}%";

            // Сохранение предложения в настройки
            Properties.Settings.Default.LastEnteredSentence = sentence;
            Properties.Settings.Default.Save();
        }

        public class Logic // класс, выполняющий логику программы
        {
            public static double CalculateLetterPercents(string sentence) // функция для определения доли букв в предложении
            {
                int letterCount = 0; // переменная для подсчета количества букв
                int totalCharacters = 0; // переменная для подсчета количества всех символов

                // проход по каждому символу в предложении
                foreach (char character in sentence)
                {
                    if (char.IsLetter(character)) // если символ является буквой
                    {
                        letterCount++; // увеличиваем счетчик букв
                    }
                    totalCharacters++; // увеличиваем счетчик всех символов
                }
                // проверка на пустую строку в предложении
                if (!(totalCharacters > 0))
                {
                    return 0; // возвращаем 0 и выводим результат о доле букв 0,00%
                }
                // вычисление доли букв в предложении и преобразование в проценты
                double letterPercents = (double)letterCount / totalCharacters * 100;
                return letterPercents; // возвращаем долю букв в процентах
            }
        }

    }
}