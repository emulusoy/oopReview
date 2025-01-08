using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oopReviewEntityProject
{
    public partial class FormStatistics : Form
    {
        public FormStatistics()
        {
            InitializeComponent();
        }
        EntityProjectDBEntities db = new EntityProjectDBEntities(); 

        private void FormStatistics_Load(object sender, EventArgs e)
        {
            //Toplam lokasyon sayisi
            lblLocationCount.Text=db.TblLocation.Count().ToString();
            
            //Toplam kapasite!
            lblTotalCapacity.Text=db.TblLocation.Sum(x => x.LocationCapacitty).ToString();
            
            //Toplam Rehber sayisi
            lblTotalGuide.Text=db.TblGuide.Count().ToString();
           //Toplam kapasite oralamasi
            lblAvarageCapacity.Text=db.TblLocation.Average(x=>x.LocationCapacitty).ToString();

            //Toplam ucret ortalamasi
            lblAveragePrice.Text = db.TblLocation.Average(x => x.LocationPrice).ToString();

            //eklenen son ulkeyi bulma
            int lastCountry =db.TblLocation.Max(x=>x.LocationId);//maximum degerin hangi idye ait oldugunu bul
            lblLastCountry.Text=db.TblLocation.Where(x=>x.LocationId==lastCountry).Select(y=>y.LocationCountry).FirstOrDefault();//o iddeki degerin country kismindaki degeri bul ve bunun ismini getir

            //Roma turunun kapasitesi!
            lblRomaCapacity.Text=db.TblLocation.Where(x=>x.LocationCity=="Roma").Select(y=>y.LocationCapacitty).FirstOrDefault().ToString();

            //Italy turunun ortalama kapasitesi
            lblItalyToursCapacity.Text = db.TblLocation.Where(x => x.LocationCountry == "Italy").Average(y => y.LocationCapacitty).ToString();

            //Roma gezisinin rehberinin ismi
            var romaGuideId=db.TblLocation.Where(x=>x.LocationCity=="Roma").Select(y=>y.GuideId).FirstOrDefault();

            lblRomaTourGuide.Text=db.TblGuide.Where(x=>x.GuideId==romaGuideId).Select(y=>y.GuideName+" "+y.GuideSurname).FirstOrDefault().ToString();

            //en yuksek kapasiteli tur hanigsi

            var maxCapacity = db.TblLocation.Max(x => x.LocationCapacitty);
            lblHighestCapacity.Text=db.TblLocation.Where(x=>x.LocationCapacitty==maxCapacity).Select(y=>y.LocationCity).FirstOrDefault().ToString();

            //En pahali tur!
            var mostTour = db.TblLocation.Max(x => x.LocationPrice);
            lblMostExpensiveTour.Text = db.TblLocation.Where(x => x.LocationPrice == mostTour).Select(y => y.LocationCity).FirstOrDefault().ToString();

            //Ayse oz kisisinin tur sayisi!

            var guideIdAyse = db.TblGuide.Where(x => x.GuideName=="Ayse" && x.GuideSurname=="Oz").Select(y=>y.GuideId).FirstOrDefault();
            lblAyseToursCount.Text=db.TblLocation.Where(x=>x.GuideId==guideIdAyse).Count().ToString();
        }
    }
}
