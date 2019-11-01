using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using System.Windows.Forms;
using Forms.ReactiveX.MessageBus;
using Forms.ReactiveX.MessageBus.Contracts;
using Forms.ReactiveX.Messages;
using Newtonsoft.Json;

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
            var message = new TestMessage<string>(this.txt_simpleBox.Text);
            _bus.Send(message);
        }

        private void Lbl_text_Click(object sender, EventArgs e) {
        }

        private void OpenFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e) {
        }

        private void Btn_OpenReactiveForm_Click(object sender, EventArgs e) {
            var form = new ReactiveForm();
            form.Show();
        }

        protected async Task<List<T>> GetExternalAsync<T>(string url) {
            var responseContent = new List<T>();

            using (var client = new HttpClient()) {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode) {
                    var content = await response.Content.ReadAsStringAsync();
                    var forceExternal = JsonConvert.DeserializeObject<List<T>>(content);
                    responseContent.AddRange(forceExternal);
                }
            }

            return responseContent;
        }
    }
}