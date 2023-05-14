using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Buying_tickets
{
    public partial class FMain : Form
    {
        public FMain()
        {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(FMain_MouseDown);
            this.MouseMove += new MouseEventHandler(FMain_MouseMove);
            this.MouseUp += new MouseEventHandler(FMain_MouseUp);

            List<string> listAeport = new List<string>()
            {
                { "«БОРИСПІЛЬ»"},
                { "«КИЇВ» (ЖУЛЯНИ)"},
                { "«ХАРКІВ»"},
                { "«ОДЕСА»"},
                { "«ДНІПРО»"},
                { "«ЛЬВІВ»"}

            };

            foreach (string aepotr in listAeport)
            {
                comboBoxAeport.Items.Add(aepotr);
            }
            comboBoxAeport.SelectedIndex = 0;



            foreach (string country in countriesAndCities.Keys)
            {
                comboBoxCountry.Items.Add(country);
            }

            comboBoxCountry.SelectedIndex = 0;
        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;


        Dictionary<string, List<string>> countriesAndCities = new Dictionary<string, List<string>>()
            {
                {"USA", new List<string>(){"New York", "Los Angeles", "Chicago"}},
                {"UK", new List<string>(){"London", "Manchester", "Birmingham"}},
                {"Canada", new List<string>(){"Toronto", "Montreal", "Vancouver"}}
            };

        private void FMain_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FMain_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void FMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void FMain_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void comboBoxAeport_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxCity.Items.Clear();

            string selectedCountry = comboBoxCountry.SelectedItem.ToString();
            List<string> cities = countriesAndCities[selectedCountry];

     
            foreach (string city in cities)
            {
                comboBoxCity.Items.Add(city);
            }

            comboBoxCity.SelectedIndex = 0;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text) && string.IsNullOrEmpty(textBoxSurName.Text))
            {
                MessageBox.Show("Заповніть всі поля", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!int.TryParse(textBoxPas.Text, out int value))
            {
                MessageBox.Show("Введіть кількість пасажирів", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (comboBoxAeport.SelectedIndex != -1)
            {
                string selectedValue = comboBoxAeport.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Виберіть аеропорт", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if(comboBoxCountry.SelectedIndex != -1)
            {
                string selectedValue = comboBoxCountry.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Виберіть країну", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (comboBoxCity.SelectedIndex != -1)
            {
                string selectedValue = comboBoxCity.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Виберіть місто", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Random random = new Random();
            int randomNumber = random.Next(10, 100);

            string name = textBoxName.Text;
            string surname = textBoxSurName.Text;
            int  pas = int.Parse(textBoxPas.Text);
            string aeport2 = comboBoxAeport.SelectedItem.ToString();
            string country = comboBoxCountry.SelectedItem.ToString();
            string city = comboBoxCity.SelectedItem.ToString();
            string date = dateTimePicker1.Text;


            if(radioButtonEconom.Checked || radioButtonBisness.Checked || radioButtonVip.Checked)
            {
                if (radioButtonEconom.Checked)
                {
                    int ptice = 150;
                    string class2 = "Економ";

                    MessageBox.Show($"\tКвиток #: {randomNumber}\n" +
                        $"\tРейс: {aeport2} - {country}({city})\n" +
                        $"\tДата зльоту: {date}\n" +
                        $"\tКлас: {class2}, ціна: {ptice}$\n" +
                        $"\tКількість пасажирів: {pas}\n" +
                        $"\tЗагальна ціна: {pas * ptice}$\n" +
                        $"\n" +
                        $"\t ПРИЄМНОГО ПОЛЬОТУ! :)\n", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (radioButtonBisness.Checked)
                {
                    int ptice = 350;
                    string class2 = "Бізнес";

                    MessageBox.Show($"\tКвиток #: {randomNumber}\n" +
                        $"\tРейс: {aeport2} - {country}({city})\n" +
                        $"\tДата зльоту: {date}\n" +
                        $"\tКлас: {class2}, ціна: {ptice}$\n" +
                        $"\tКількість пасажирів: {pas}\n" +
                        $"\tЗагальна ціна: {pas * ptice}$\n" +
                        $"\n" +
                        $"\t ПРИЄМНОГО ПОЛЬОТУ! :)\n", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (radioButtonVip.Checked)
                {
                    int ptice = 1500;
                    string class2 = "VIP";

                    MessageBox.Show($"\tКвиток #: {randomNumber}\n" +
                        $"\tРейс: {aeport2} - {country}({city})\n" +
                        $"\tДата зльоту: {date}\n" +
                        $"\tКлас: {class2}, ціна: {ptice}$\n" +
                        $"\tКількість пасажирів: {pas}\n" +
                        $"\tЗагальна ціна: {pas * ptice}$\n" +
                        $"\n" +
                        $"\tПРИЄМНОГО ПОЛЬОТУ! :)\n", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Виберіть клас", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

          
        }
    }
}
