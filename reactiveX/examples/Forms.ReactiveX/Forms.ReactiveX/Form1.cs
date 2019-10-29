using System;
using System.Reactive.Subjects;
using System.Windows.Forms;
using Forms.ReactiveX.MessageBus.Contracts;
using Forms.ReactiveX.Messages;

namespace Forms.ReactiveX {
    public partial class Form1 : Form {
        private readonly IMessageBus _bus;
        public Form1() {
            InitializeComponent();
            _subject.Subscribe(t => this.lbl_text.Text = t);
            _bus = LazyBus.GetInstance.Bus;
        }

        private readonly Subject<string> _subject = new Subject<string>();

        private void Txt_simpleBox_TextChanged(object sender, EventArgs e) {
            _subject.OnNext(this.txt_simpleBox.Text);
            var message = new TestMessage();
            message.SetData(this.txt_simpleBox.Text);
            _bus.Send(message);
        }

        private void Lbl_text_Click(object sender, EventArgs e) {
        }

        private void OpenFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Btn_OpenReactiveForm_Click(object sender, EventArgs e)
        {
            var form = new ReactiveForm();
            form.Show();
        }
    }
}