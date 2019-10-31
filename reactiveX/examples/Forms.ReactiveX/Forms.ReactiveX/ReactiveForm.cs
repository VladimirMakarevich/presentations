using Forms.ReactiveX.MessageBus.Contracts;
using Forms.ReactiveX.Messages;
using System;
using System.Windows.Forms;
using Forms.ReactiveX.MessageBus;

namespace Forms.ReactiveX {
    public partial class ReactiveForm : Form {
        private readonly IMessageBus _bus;

        public ReactiveForm() {
            InitializeComponent();

            _bus = LazyBus.GetInstance.Bus;
            _bus.Listen(new TestMessage<string>()).Subscribe(
                message => {
                    if (message != null) {
                        this.lbl_ReactiveForm.Text = ((TestMessage<string>) message).Data;
                    }
                }, (error) => { MessageBox.Show(error.ToString()); },
                () => { MessageBox.Show("Completed"); });
        }

        private void Lbl_ReactiveForm_Click(object sender, EventArgs e) {
        }
    }
}