using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AutomobileLibrary.BussinessObject;
using AutomobileLibrary.DataAccess;
using AutomobileLibrary.Repository; 


namespace AutoMobileWinApp
{
    public partial class frmCarDetails : Form
    {
        public frmCarDetails()
        {
            InitializeComponent();
        }

        public ICarRepository CarRepository { get; set; }   
        public bool InsertOrUpdate { get; set; }    // false insert true update 
        public Car CarInfo { get; set; }    


        public void frmCarDetail_Load (object sender, EventArgs e)
        {
            cboManufacture.SelectedIndex= 0;
            txtCarID.Enabled = !InsertOrUpdate;

            if (InsertOrUpdate == true)
            {
                txtCarID.Text   = CarInfo.CarId.ToString();
                txtCarName.Text = CarInfo.CarName; 
                txtPrice.Text = CarInfo.Price.ToString();
                txtReleaseYear.Text= CarInfo.ReleaseYear.ToString();
                cboManufacture.Text = CarInfo.Manufacturer.Trim();
             }
        }
       


  

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                var car = new Car
                {
                    CarId = int.Parse(txtCarID.Text),
                    CarName = txtCarName.Text,
                    Manufacturer = cboManufacture.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    ReleaseYear = int.Parse(txtReleaseYear.Text),
                };
                if (InsertOrUpdate == false)
                {
                    CarRepository.InsertCar(car);
                }

                else
                {
                    CarRepository.UpdateCar(car);
                }
               
            }
            catch (Exception ex)
            {

                MessageBox.Show("da ton tai");
            }
        }

        private void tbnCancel_Click(object sender, EventArgs e) => Close();

        private void txtCarID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
