using DanhGiaDoanVien.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DanhGiaDoanVien
{
    public partial class FormEvaluateGroup : Form
    {
        public FormEvaluateGroup()
        {
            InitializeComponent();
        }

        //method
        private ScoresGroup EvaluateGroup(ScoresGroup scoresGroup)
        {
            if (((scoresGroup.GreatMember / scoresGroup.TotalMember) * 100) >= 80 && scoresGroup.BabMember == 0)
            {
                scoresGroup.Rank = "Chi đoàn vững mạnh";
            }
            else if (((scoresGroup.GreatMember / scoresGroup.TotalMember) * 100) >= 60 && scoresGroup.BabMember == 0)
            {
                scoresGroup.Rank = "Chi đoàn khá";
            }
            else if (((scoresGroup.GreatMember / scoresGroup.TotalMember) * 100) >= 50 && ((scoresGroup.BabMember / scoresGroup.TotalMember) * 100) <= 20)
            {
                scoresGroup.Rank = "Chi đoàn trung bình";
            }
            else
            {
                scoresGroup.Rank = "Chi đoàn yếu kém";
            }

            return scoresGroup;
        }

        private ScoresGroup CountRankMember(ScoresGroup scoresGroup, ScoresStudent[] listMember)
        {
            for (int i = 0; i < listMember.Length; i++)
            {
                if (listMember[i].Rank == "Xuất sắc")
                {
                    scoresGroup.ExcellentMember++;
                }
                else if (listMember[i].Rank == "Khá")
                {
                    scoresGroup.GreatMember++;
                }
                else if (listMember[i].Rank == "Trung bình")
                {
                    scoresGroup.MediumMember++;
                }
                else if (listMember[i].Rank == "Yếu kém")
                {
                    scoresGroup.BabMember++;
                }
            }
            scoresGroup.TotalMember = (byte)(listMember.Length + 1);

            return scoresGroup;
        }
        private ScoresGroup CountRankMember(ScoresGroup scoresGroup, ScoresTeacher[] listMember)
        {
            for (int i = 0; i < listMember.Length; i++)
            {
                if (listMember[i].Rank == "Xuất sắc")
                {
                    scoresGroup.ExcellentMember++;
                }
                else if (listMember[i].Rank == "Khá")
                {
                    scoresGroup.GreatMember++;
                }
                else if (listMember[i].Rank == "Trung bình")
                {
                    scoresGroup.MediumMember++;
                }
                else if (listMember[i].Rank == "Yếu kém")
                {
                    scoresGroup.BabMember++;
                }
            }
            scoresGroup.TotalMember = (byte)(listMember.Length + 1);

            return scoresGroup;
        }
    }
}
