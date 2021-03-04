using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lr1_Db_WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Invisible();
        }

        private void Invisible()
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
        }

        private void kategoriesDataGridFill()
        {
            Context db = new Context();
            int b = 0;
            foreach (var a in db.kategories)
            {
                b++;
            }
            int i = 1;
            Grid.ColumnCount = 2;
            Grid.RowCount = b + 1;
            Grid.Rows[0].Cells[1].Value = "Название категории";
            Grid.ColumnHeadersVisible = false;


            foreach (var k in db.kategories)
            {
                Grid.Rows[i].Cells[1].Value = k.name;
                i++;
            }
            DeleteButtom(Grid.RowCount);
        }

        private void manufactureDataGridFill()
        {
            Context db = new Context();
            int b = 0;
            foreach (var a in db.manufacturers)
            {
                b++;
            }
            int i = 1;
            Grid.ColumnCount = 4;
            Grid.RowCount = b + 1;
            Grid.Rows[0].Cells[1].Value = "Название производителя";
            Grid.Rows[0].Cells[2].Value = "Страна производителя";
            Grid.Rows[0].Cells[3].Value = "Лет сотрудничества";
            Grid.ColumnHeadersVisible = false;


            foreach (var m in db.manufacturers)
            {
                Grid.Rows[i].Cells[1].Value = m.companyName;
                Grid.Rows[i].Cells[2].Value = m.county;
                Grid.Rows[i].Cells[3].Value = m.yearsOfCooperation;
                i++;
            }
            DeleteButtom(Grid.RowCount);
        }

        private void furnitureDataGridFill()
        {
            Context db = new Context();
            int b = 0;
            foreach (var a in db.furnitures)
            {
                b++;
            }
            int i = 1;
            Grid.ColumnCount = 4;
            Grid.RowCount = b + 1;
            Grid.Rows[0].Cells[1].Value = "Цена мебели";
            Grid.Rows[0].Cells[2].Value = "Id категории";
            Grid.Rows[0].Cells[3].Value = "Id производителя";
            Grid.ColumnHeadersVisible = false;


            foreach (var f in db.furnitures)
            {
                Grid.Rows[i].Cells[1].Value = f.Price;
                Grid.Rows[i].Cells[2].Value = f.kategories;
                Grid.Rows[i].Cells[3].Value = f.manufacturer; ;
                i++;
            }
            DeleteButtom(Grid.RowCount);
        }

        private void deliveryDataGridFill()
        {
            Context db = new Context();
            int b = 0;
            foreach (var a in db.deliveries)
            {
                b++;
            }
            int i = 1;
            Grid.ColumnCount = 4;
            Grid.RowCount = b + 1;
            Grid.Rows[0].Cells[1].Value = "Адресс доставки";
            Grid.Rows[0].Cells[2].Value = "Дата доставки";
            Grid.Rows[0].Cells[3].Value = "Id мебели";
            Grid.ColumnHeadersVisible = false;


            foreach (var d in db.deliveries)
            {
                Grid.Rows[i].Cells[1].Value = d.adres;
                Grid.Rows[i].Cells[2].Value = d.Date;
                Grid.Rows[i].Cells[3].Value = d.furniture;
                i++;
            }
            DeleteButtom(Grid.RowCount);
        }

        private void DeleteButtom(int rowsCount)
        {
            for (int i = 1; i < rowsCount; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                Grid[0, i] = linkCell;
                Grid[0, i].Value = "Удалить";
            }
        }

        private void comboBox1_MouseLeave(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
                if (comboBox1.SelectedIndex == 0)
                {
                    Invisible();
                    kategoriesDataGridFill();
                    label1.Visible = true;
                    label1.Text = "Название категории: ";
                    textBox1.Visible = true;
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    Invisible();
                    manufactureDataGridFill();
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label1.Text = "Название производителя";
                    label2.Text = "Страна производителя";
                    label3.Text = "Лет сотрудничества";
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    Invisible();
                    furnitureDataGridFill();
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label1.Text = "Цена мебели";
                    label2.Text = "Id категории";
                    label3.Text = "Id производителя";
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    Invisible();
                    deliveryDataGridFill();
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label1.Text = "Адресс доставки";
                    label2.Text = "Дата доставки";
                    label3.Text = "Id мебели";
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                Kategories kategories = new Kategories { name = textBox1.Text};
                kategories.KategoriesAdd(kategories);
                kategoriesDataGridFill();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                Manufacturer manufacturer = new Manufacturer { companyName = textBox1.Text, county = textBox2.Text, 
                    yearsOfCooperation = Convert.ToInt32(textBox3.Text)};
                manufacturer.ManufacturerAdd(manufacturer);
                manufactureDataGridFill();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                Furniture furniture = new Furniture();
                furniture.FurnitureAdd(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
                furnitureDataGridFill();
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                Delivery delivery = new Delivery();
                delivery.DeliveryAdd(textBox1.Text, textBox2.Text, Convert.ToInt32(textBox3.Text));
                deliveryDataGridFill();
            }
        }

        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Context db = new Context();
            if (e.ColumnIndex == 0)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    int i = 0;
                    Kategories kategories = new Kategories();
                    foreach(var a in db.kategories)
                    {
                        if(i == e.RowIndex - 1)
                        {
                            kategories = a;
                        }
                        i++;
                        
                    }
                    db.kategories.Remove(kategories);
                    db.SaveChanges();
                    kategoriesDataGridFill();
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    int i = 0;
                    Manufacturer manufacturer = new Manufacturer();
                    foreach (var a in db.manufacturers)
                    {
                        if (i == e.RowIndex - 1)
                        {
                            manufacturer = a;
                        }
                        i++;
                    }
                    db.manufacturers.Remove(manufacturer);
                    db.SaveChanges();
                    manufactureDataGridFill();
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    int i = 0;
                    Furniture furniture = new Furniture();
                    foreach (var a in db.furnitures)
                    {
                        if (i == e.RowIndex - 1)
                        {
                            furniture = a;
                        }
                        i++;
                    }
                    db.furnitures.Remove(furniture);
                    db.SaveChanges();
                    furnitureDataGridFill();
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    int i = 0;
                    Delivery delivery= new Delivery();
                    foreach (var a in db.deliveries)
                    {
                        if (i == e.RowIndex - 1)
                        {
                            delivery = a;
                        }
                        i++;
                    }
                    db.deliveries.Remove(delivery);
                    db.SaveChanges();
                    deliveryDataGridFill();
                }
            }
        }

        private void Grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Context db = new Context();
            if (checkBox1.Checked)
                if (comboBox1.SelectedIndex == 0)
                {
                    if (e.ColumnIndex == 1)
                    {
                        int i = 0;
                        foreach (var a in db.kategories)
                        {
                            if (i == e.RowIndex - 1)
                            {
                                a.name = Grid[1, e.RowIndex].Value.ToString();
                            }
                            i++;
                        }
                        db.SaveChanges();
                        kategoriesDataGridFill();
                    }

                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    if (e.ColumnIndex == 1)
                    {
                        int i = 0;
                        foreach (var a in db.manufacturers)
                        {
                            if (i == e.RowIndex - 1)
                            {
                                a.companyName = Grid[1, e.RowIndex].Value.ToString();
                            }
                            i++;
                        }
                        db.SaveChanges();
                        manufactureDataGridFill();
                    }
                    else if (e.ColumnIndex == 2) 
                    {
                        int i = 0;
                        foreach (var a in db.manufacturers)
                        {
                            if (i == e.RowIndex - 1)
                            {
                                a.county = Grid[1, e.RowIndex].Value.ToString();
                            }
                            i++;
                        }
                        db.SaveChanges();
                        manufactureDataGridFill();
                    }
                    else if (e.ColumnIndex == 3) 
                    {
                        int i = 0;
                        foreach (var a in db.manufacturers)
                        {
                            if (i == e.RowIndex - 1)
                            {
                                a.yearsOfCooperation = Convert.ToInt32(Grid[1, e.RowIndex].Value.ToString());
                            }
                            i++;
                        }
                        db.SaveChanges();
                        manufactureDataGridFill();
                    }
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    if (e.ColumnIndex == 1)     
                    {
                        int i = 0;
                        foreach (var a in db.deliveries)
                        {
                            if (i == e.RowIndex - 1)
                            {
                                a.adres = Grid[1, e.RowIndex].Value.ToString();
                            }
                            i++;
                        }
                        db.SaveChanges();
                        deliveryDataGridFill();
                    }
                    else if (e.ColumnIndex == 2)    
                    {
                        int i = 0;
                        foreach (var a in db.deliveries)
                        {
                            if (i == e.RowIndex - 1)
                            {
                                a.Date = Grid[1, e.RowIndex].Value.ToString();
                            }
                            i++;
                        }
                        db.SaveChanges();
                        deliveryDataGridFill();
                    }
                    else if (e.ColumnIndex == 3) 
                    {
                        int i = 0;
                        foreach (var a in db.deliveries)
                        {
                            if (i == e.RowIndex - 1)
                            {
                                foreach(var b in db.furnitures)
                                {
                                    if(b.Id == Convert.ToInt32(Grid[1, e.RowIndex].Value.ToString()))
                                    {
                                        a.furniture = b;
                                    }
                                }
                            }
                            i++;
                        }
                        db.SaveChanges();
                        deliveryDataGridFill();
                    }
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    if (e.ColumnIndex == 1)
                    {
                        int i = 0;
                        foreach (var a in db.furnitures)
                        {
                            if (i == e.RowIndex - 1)
                            {
                                a.Price = Convert.ToInt32(Grid[1, e.RowIndex].Value.ToString());
                            }
                            i++;
                        }
                        db.SaveChanges();
                        furnitureDataGridFill();
                    }
                    else if (e.ColumnIndex == 2)
                    {
                        int i = 0;
                        foreach (var a in db.furnitures)
                        {
                            if (i == e.RowIndex - 1)
                            {
                                foreach (var b in db.kategories)
                                {
                                    if (b.Id == Convert.ToInt32(Grid[1, e.RowIndex].Value.ToString()))
                                    {
                                        a.kategories = b;
                                    }
                                }
                            }
                            i++;
                        }
                        db.SaveChanges();
                        furnitureDataGridFill();
                    }
                    else if (e.ColumnIndex == 3)
                    {
                        int i = 0;
                        foreach (var a in db.furnitures)
                        {
                            if (i == e.RowIndex - 1)
                            {
                                foreach (var b in db.manufacturers)
                                {
                                    if (b.Id == Convert.ToInt32(Grid[1, e.RowIndex].Value.ToString()))
                                    {
                                        a.manufacturer = b;
                                    }
                                }
                            }
                            i++;
                        }
                        db.SaveChanges();
                        furnitureDataGridFill();
                    }
                }
        }
    }
}
