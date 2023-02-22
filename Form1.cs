using System.Linq;
using System.Windows.Forms;

namespace WeatherApp
{
    public partial class WeatherForm : Form
    {
        private WeatherDatabase _weather;

        public WeatherForm()
        {
            InitializeComponent();

            _weather = new WeatherDatabase();
            _weather.Initialize();

            WeatherDataGrid.DataSource = _weather.Weathers.ToList();
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)) { WeatherDataGrid.DataSource = _weather.Weathers; return; }
            WeatherDataGrid.DataSource = _weather.Weathers
                .Where(t => t.CityName.ToLower().Contains(textBox1.Text.ToLower()))
                .ToList();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            WeatherDataGrid.DataSource = _weather.Weathers;
            textBox1.Text =string.Empty;
            comboBox1.Text = string.Empty;
        }

        private void comboBox1_SelectedValueChanged(object sender, System.EventArgs e)
        {
            if(comboBox1.SelectedItem !=null)
            {
                var vb = comboBox1.SelectedItem as string;
                WeatherDataGrid.DataSource = _weather.Weathers
                    .Where(n=>n.MeasureUnit.ToString()==vb)
                    .ToList();
                return;
            }
            WeatherDataGrid.DataSource = _weather.Weathers;
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            WeatherDataGrid.DataSource = _weather.Weathers
                .OrderBy(k => k.Temperature)
                .ToList();
        }
    }
}