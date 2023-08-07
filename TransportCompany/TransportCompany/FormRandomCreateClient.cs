using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransportCompanyContracts.BindingModels;
using TransportCompanyContracts.BusinessLogicsContracts;

namespace TransportCompany
{
    public partial class FormRandomCreateClient : Form
    {
        private readonly IClientLogic _logicC;

        Random rnd = new Random(DateTime.Now.ToString().GetHashCode());

        private string[] _names = { "Иван", "Егор", "Роман", "Денис", "Игнат", "Ренат", "Никита", "Павел", "Данил", "Максим", "Николай", "Дмитрий", "Владислав", "Марк", "Булат", "Марсель", "Назар", "Багир", "Кирилл", "Всеволод", "Ярослав", "Юрий", "Виталий" };

        private string[] _surnames = { "Иванов", "Елисеев", "Марков", "Негин", "Мусоев", "Сегреев", "Распаев", "Минаров", "Захарченко", "Пятаков", "Юдаков", "Карташев", "Селин", "Марков", "Захаров", "Никитин", "Распаев", "Алексанян", "Скалкин", "Строев", "Горшков", "Каримов", "Кочкадаев", "Ершов", "Алиакберов", "Закуанов", "Пахомов" };

        private string[] _patronymics = { "Иванович", "Евгеньевич", "Егорович", "Николаевич", "Дмитриевич", "Владиславович", "Юрьевич", "Кириллович", "Артемиевич", "Павлович", "Максимович", "Назарович", "Багирович", "Булатович", "Всеволодович", "Витальевич", "Евгеньевич", "Романович", "Ярославович", "Данилович", "Зульфия", "Марсельевич", "Маркович", };

        private string[] _telephones = { "89529876316", "88804293534", "84508874804", "82035754008", "80926246994", "83316923921", "88497436387", "82372606638", "81582656294", "83605675249", "87978864427", "81882538381", "83432311066", "80220603131", "82166498710", "80271945648", "83581821702", "84911615179", "89993116947", "80830482909", "89463846784", "84817550460", "81785373218", "80654035595", "81304432863", "85601863128" };

        private string[] _emails = { "deffabuttiprei-5025@yopmail.com", "quiquoucrobrilla-7902@yopmail.com", "tucoffokexoi-9537@yopmail.com", "nebroijulleinne-7231@yopmail.com", "xedeujezoilli-1668@yopmail.com", "foikoussoidouhau-5112@yopmail.com", "pruddougoddeda-2757@yopmail.com", "keidevoillaga-5758@yopmail.com", "palemeinnacra-4165@yopmail.com", "capribukoippa-8523@yopmail.com", "truwauheineita-8708@yopmail.com", "mudebralanu-3594@yopmail.com", "nuxauttisoibri-7020@yopmail.com", "dufenosatte-4543@yopmail.com", "xullusaquilou-9479@yopmail.com", "broixifrommelle-3859@yopmail.com", "yimozofreixeu-4046@yopmail.com", "wetrouddemoro-9168@yopmail.com", "crepropretaji-6969@yopmail.com", "pahoufforutre-6805@yopmail.com", "gretreidineuba-8655@yopmail.com", "koullinnorulli-5851@yopmail.com", "bougreigewetto-3164@yopmail.com", "brocoffanauba-5102@yopmail.com", "kaddasumetre-7742@yopmail.com", "heussouprogromu-7061@yopmail.com", "teresitruffe-8881@yopmail.com", "kejicrouzazei-9377@yopmail.com", "zoicaquaugrili-2744@yopmail.com", "quepifrucragrou-8404@yopmail.com", "graditilladdi-7217@yopmail.com", "doboijifammeu-4816@yopmail.com", "tobrograusessoi-6295@yopmail.com", "xeifeuffiyoka-8243@yopmail.com", "greuquekucaju-9438@yopmail.com", "prisseproittunne-3785@yopmail.com", "vuppeiyatrare-8690@yopmail.com", "pennibexewa-9132@yopmail.com", "gayufeppaucu-4744@yopmail.com", "boicegreisussa-1695@yopmail.com" };

        public FormRandomCreateClient(IClientLogic logicC)
        {
            InitializeComponent();

            _logicC = logicC;
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            try
            {
                ChangeList(_telephones);

                ChangeList(_emails);

                textBoxTimeWork.Text = _logicC.TestRandomCreate(Convert.ToInt32(textBoxCount.Text), _names, _surnames, _patronymics, _telephones, _emails);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ChangeList(string[] _strings)
        {
            for(int i = 0; i < _strings.Length; i++)
            {
                _strings[i] = Convert.ToString(rnd.Next(0, 800000)) + _strings[i];
            }
        }
    }
}
