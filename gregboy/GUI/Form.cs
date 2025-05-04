using System;
using System.Windows.Forms;

namespace Gregboy {
    public partial class Form : System.Windows.Forms.Form {

        gregboy AA;

        public Form() {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e) {
            AA = new gregboy(this);
        }

        private void Key_Down(object sender, KeyEventArgs e) {
            if (AA.power_switch) AA.joypad.handleKeyDown(e);
        }

        private void Key_Up(object sender, KeyEventArgs e) {
            if (AA.power_switch) AA.joypad.handleKeyUp(e);
        }

        private void Drag_Drop(object sender, DragEventArgs e) {
            string[] cartNames = (string[])e.Data.GetData(DataFormats.FileDrop);
            AA.POWER_ON(cartNames[0]);
        }

        private void Drag_Enter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.All;
            AA.POWER_OFF();
        }

    }
}
