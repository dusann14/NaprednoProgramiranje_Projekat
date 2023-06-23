using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent
{
    public class Koordinator
    {
        private static Koordinator instance;
        public static Koordinator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Koordinator();
                }
                return instance;
            }
        
        }

        private Koordinator()
        {
            loginKontroler = new LoginKontroler();
        }

        private LoginKontroler loginKontroler;

        public void OtvoriLoginFormu()
        {
            Komunikacija.Instance.PoveziSe();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FrmLogin frmLogin = loginKontroler.NapraviFrmLogin();
            frmLogin.AutoSize = true;
            Application.Run(frmLogin);
        }

        public void OtvoriBibliotekarFormu()
        {
            
        }
        public void OtvoriClanFormu()
        {
            
        }

    }
}
