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
                // Попытка преобразовать введенное значение в число и проверка на диапазон от 1 до 9999
                if (int.TryParse(textBox1.Text, out n) && n >= 1 && n <= 9999)
                {
                    // Вызов метода FormatCost и вывод результата
                    labelResult.Text = Logic.FormatCost(n);
                    // Сохранение значения в настройках
                    Properties.Settings.Default.LastEnteredValue = n;
                    Properties.Settings.Default.Save();

                }
                else
                {
                    // Сообщение об ошибке, если ввод неверен
                    labelResult.Text = "Введите число от 1 до 9999.";
                }
            }
            catch (Exception ex)
            {
                return; // прерываем обработчик клика, если ввели какую-то ерунду
            }
        }

    }

    public class Logic
    {
        public static string GetRublesWord(int rubles) // для определения правильного написания слова "рубль" в зависимости от количества
        {
            // для всех чисел, оканчиваемых на 1, кроме числа "11"
            if (rubles == 1 || (rubles % 10 == 1 && rubles != 11))
            {
                return "рубль";
            }
            // для всех чисел, оканчиваемых на 2, 3, 4, кроме чисел от "12" до "14"
            else if ((rubles >= 2 && rubles <= 4) || ((rubles % 10 >= 2 && rubles % 10 <= 4) && (rubles < 10 || rubles > 20)))
            {
                return "рубля";
            }
            // для всех остальных чисел
            else
            {
                return "рублей";
            }
        }

        public static string GetKopecksWord(int kopecks) // функция для определения правильного написания слова "копейка" в зависимости от количества
        {
            // для всех чисел, оканчиваемых на 1, кроме числа "11"
            if (kopecks == 1 || (kopecks % 10 == 1 && kopecks != 11))
            {
                return "копейка";
            }
            // для всех чисел, оканчиваемых на 2, 3, 4, кроме чисел от "12" до "14"
            else if ((kopecks >= 2 && kopecks <= 4) || ((kopecks % 10 >= 2 && kopecks % 10 <= 4) && (kopecks < 10 || kopecks > 20)))
            {
                return "копейки";
            }
            // для всех остальных чисел
            else
            {
                return "копеек";
            }
        }

        public static (int, string, int, string) CalculateCost(int n) // функция для разделения стоимости на рубли и копейки
        {
            int rubles = n / 100; // определение количества рублей
            int kopecks = n % 100; // определения количества копеек
            string rublesWord = GetRublesWord(rubles); // обращение к функции GetRublesWord, чтобы определить написание слова "рубль"
            string kopecksWord = GetKopecksWord(kopecks); // обращение к функции GetKopecksWord, чтобы определить написание слова "копейка"
            return (rubles, rublesWord, kopecks, kopecksWord); // возвращаем полученные значения в FormatCost
        }

        public static string FormatCost(int n) // функция для форматированного вывода стоимости
        {
            var (rubles, rublesWord, kopecks, kopecksWord) = CalculateCost(n); // расчитываем данные в функции CalculateCost

            if (kopecks == 0) // если нет копеек, то выводим только рубли
            {
                return $"Стоимость: {rubles} {rublesWord} ровно";
            }
            else // если копейки есть, то выводим и рубли и копейки
            {
                return $"Стоимость: {rubles} {rublesWord} {kopecks} {kopecksWord}";
            }
        }
    }
}