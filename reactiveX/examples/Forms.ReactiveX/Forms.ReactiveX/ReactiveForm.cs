using Forms.ReactiveX.MessageBus.Contracts;
using Forms.ReactiveX.Messages;
using System;
using System.Windows.Forms;

namespace Forms.ReactiveX
{
    public partial class ReactiveForm : Form
    {
        private readonly IMessageBus _bus;
        public ReactiveForm()
        {
            InitializeComponent();
            _bus = LazyBus.GetInstance.Bus;
            _bus.Listen(new TestMessage()).Subscribe(c => {
                if (c != null) {
                    this.lbl_ReactiveForm.Text = c.GetData();
                }
            });
        }

        private void Lbl_ReactiveForm_Click(object sender, EventArgs e)
        {

        }
    }
}
