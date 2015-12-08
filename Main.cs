using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Main : Form
    {
        Car myCar;

        public Main()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Validating wether or not the car can be on the road.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnValidate_Click(object sender, EventArgs e)
        {
            string strPlate = tbCarPlate.ToString();

            // creating the car
            try
            {
                myCar = new Car(strPlate);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
                
                return;
            }

            // validating time
            Regex rx = new Regex("[0|1][0-9]|[2][0-3]:[0-5][0-9]");

            string strTime = "";
            if (rx.IsMatch(tbTime.ToString()))
                strTime = tbTime.ToString();
            else
            {
                MessageBox.Show("Invalid Time Format",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);

                return;
            }

            // validating wether or not the car can be on the road

            // peak time
            if (!IsPeakTime(strTime))
            {
                MessageBox.Show("This car can be on the Road.",
                "Message",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);

                return;
            }

            // day of week
            if (myCar.CanBeOnRoad(dtpDate.Value.DayOfWeek))
                MessageBox.Show("This car can be on the Road.",
                "Message",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
            else
                MessageBox.Show("This car can NOT be on the Road.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);

        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpTime_ValueChanged(object sender, EventArgs e)
        {

        }

        private bool IsPeakTime(string strTime)
        {
            TimeSpan fromAM = new TimeSpan(7, 0, 0), toAM = new TimeSpan(9, 30, 0); // peak time in the morning
            TimeSpan fromPM = new TimeSpan(16, 0, 0), toPM = new TimeSpan(19, 30, 0); // peak time in the afternoon
            
            String[] timeParts = strTime.Split(':');
            TimeSpan time = new TimeSpan(Int16.Parse(timeParts[1].ToString()), Int16.Parse(timeParts[2].ToString()), 0);

            return (time > fromAM && time < toAM) || (time > fromPM && time < toPM);
        }
    }
}
