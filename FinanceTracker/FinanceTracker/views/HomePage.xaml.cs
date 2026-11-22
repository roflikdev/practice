using System;
using System.Data;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FinanceTracker.views
{
    public partial class HomePage : Page
    {
        private readonly Database database = new Database();
        private readonly CultureInfo culture = CultureInfo.GetCultureInfo("ru-RU");

        public HomePage()
        {
            InitializeComponent();
            DateBox.SelectedDate = DateTime.Today;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadOperations();
        }

        private async Task LoadOperations()
        {
            SetBusy(true);
            StatusText.Text = "Загрузка...";
            try
            {
                var table = await Task.Run(() => database.GetOperations());
                HistoryGrid.ItemsSource = table.DefaultView;
                decimal income = 0;
                decimal expense = 0;
                foreach (DataRow row in table.Rows)
                {
                    decimal amount = (decimal)row["Amount"];
                    if (amount > 0)
                        income += amount;
                    else
                        expense -= amount;
                }
                decimal balance = income - expense;
                BalanceText.Text = balance.ToString("N2", culture) + " ₽";
                BalanceText.Foreground = balance < 0 ? Brushes.Firebrick : Brushes.ForestGreen;
                IncomeText.Text = income.ToString("N2", culture) + " ₽";
                ExpenseText.Text = expense.ToString("N2", culture) + " ₽";
                StatusText.Text = table.Rows.Count == 0 ? "Пока нет записей. Добавьте первый доход или расход." : "Записей: " + table.Rows.Count;
            }
            catch (Exception)
            {
                HistoryGrid.ItemsSource = null;
                BalanceText.Text = "—";
                IncomeText.Text = "—";
                ExpenseText.Text = "—";
                StatusText.Text = "Не удалось загрузить историю. Проверьте подключение к базе данных и нажмите «Обновить».";
            }
            finally
            {
                SetBusy(false);
            }
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            decimal amount;
            string value = AmountBox.Text.Trim().Replace(',', '.');
            if (!decimal.TryParse(value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out amount)
                || amount <= 0 || amount > 9999999999.99m || decimal.Round(amount, 2) != amount)
            {
                StatusText.Text = "Введите положительную сумму с точностью до копеек (не больше 9 999 999 999,99).";
                AmountBox.Focus();
                return;
            }
            DateTime enteredDate;
            if (!DateTime.TryParse(DateBox.Text, culture, DateTimeStyles.None, out enteredDate))
            {
                StatusText.Text = "Выберите дату операции.";
                return;
            }
            int type = TypeBox.SelectedIndex == 1 ? 1 : 2;
            DateTime date = enteredDate.Date;
            string description = DescriptionBox.Text.Trim();
            SetBusy(true);
            try
            {
                await Task.Run(() => database.AddOperation(type, amount, date, description));
            }
            catch (Exception)
            {
                StatusText.Text = "Не удалось сохранить запись. Проверьте подключение и обновите историю перед повторной попыткой.";
                SetBusy(false);
                return;
            }
            AmountBox.Clear();
            DescriptionBox.Clear();
            await LoadOperations();
        }

        private async void Refresh_Click(object sender, RoutedEventArgs e)
        {
            await LoadOperations();
        }

        private void SetBusy(bool busy)
        {
            AddButton.IsEnabled = !busy;
            RefreshButton.IsEnabled = !busy;
            TypeBox.IsEnabled = !busy;
            AmountBox.IsEnabled = !busy;
            DateBox.IsEnabled = !busy;
            DescriptionBox.IsEnabled = !busy;
        }
    }
}
