using System;
using System.Reactive.Subjects;
using System.Windows.Forms;

namespace Forms.ReactiveX {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            _subject.Subscribe(t => this.lbl_text.Text = t);
        }

        private readonly Subject<string> _subject = new Subject<string>();

        private void Txt_simpleBox_TextChanged(object sender, EventArgs e) {
            _subject.OnNext(this.txt_simpleBox.Text);
        }

        private void Lbl_text_Click(object sender, EventArgs e) {
        }
    }
}