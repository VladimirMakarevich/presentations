using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;

namespace Console.ReactiveX {
    public class Program {
        public static void Main(string[] args) {
//            System.Console.WriteLine("Observable Range:\n");
//            ObservableRange();
//            System.Console.WriteLine("\n\n/------------------------------------------------------/");
//            System.Console.ReadKey();
//
//            System.Console.WriteLine("\nParallel Execution (CombineLatest):\n");
//            ParallelExecution();
//            System.Console.WriteLine("\n\n/------------------------------------------------------/");
//            System.Console.ReadKey();
//
//            System.Console.WriteLine("\nConvert List to Observable:\n");
//            ConvertToObservable();
//            System.Console.WriteLine("\n\n/------------------------------------------------------/");
//            System.Console.ReadKey();
//
//            System.Console.WriteLine("\nWrite one number per second (Interval):\n");
//            OneNumberPerSecond();
//            System.Console.WriteLine("\n\n/------------------------------------------------------/");
//            System.Console.ReadKey();
//
//            System.Console.WriteLine("\nBuffer:\n");
//            Buffer();
//            System.Console.WriteLine("\n\n/------------------------------------------------------/");
//            System.Console.ReadKey();
//
//            System.Console.WriteLine("\nThrottle:\n");
//            Throttle();
//            System.Console.WriteLine("\n\n/------------------------------------------------------/");
//            System.Console.ReadKey();

            System.Console.WriteLine("\nMerge:\n");
            Merge();
            System.Console.WriteLine("\n\n/------------------------------------------------------/");
            System.Console.ReadKey();

            System.Console.WriteLine("\nConcat Observable:\n");
            ConcatObservable();
            System.Console.WriteLine("\n\n/------------------------------------------------------/");
            System.Console.ReadKey();

            System.Console.WriteLine("\nThe End.\n");
            System.Console.WriteLine("Completed. PRESS => ME to close.");
            System.Console.ReadKey();
        }

        private static void ConcatObservable() {
            using (Xs.Concat(Ys).Timestamp().Subscribe(
                z => System.Console.WriteLine($"{z.Value}: {z.Timestamp}"),
                () => System.Console.WriteLine("Completed. PRESS => ME"))) {
                System.Console.ReadKey();
            }
        }

        private static IObservable<int> Xs => Generate(0, new List<int> {
            1, 2, 2, 2
        });

        private static IObservable<int> Ys => Generate(100, new List<int> {
            2, 2, 2, 2
        });

        private static IObservable<int> Generate(int initialValue, IList<int> intervals) {
            intervals.Add(0);
            return Observable.Generate(initialValue,
                x => x < initialValue + intervals.Count - 1,
                x => x + 1,
                x => x,
                x => TimeSpan.FromSeconds(intervals[x - initialValue]));
        }

        private static void Merge() {
            using (Xs.Merge(Ys).Timestamp().Subscribe(
                z => System.Console.WriteLine($"{z.Value}: {z.Timestamp}"),
                () => System.Console.WriteLine("Completed. PRESS => ME"))) {
                System.Console.ReadKey();
            }
        }

        private static void Throttle() {
            var observable = GenerateAlternatingFastAndSlowEvents().ToObservable().Timestamp();

            var throttled = observable.Throttle(TimeSpan.FromMilliseconds(750));
            using (throttled.Subscribe(x => System.Console.WriteLine($"{x.Value}: {x.Timestamp}"))) {
                System.Console.WriteLine("PRESS ME => to unsubscribe");
                System.Console.ReadKey();
            }
        }

        private static IEnumerable<int> GenerateAlternatingFastAndSlowEvents() {
            int i = default;
            while (true) {
                if (i > 1000) {
                    yield break;
                }

                yield return i;
                i++;
                Thread.Sleep(i % 10 < 5 ? 500 : 1000);
            }
        }

        private static void Buffer() {
            var inbox = EndlessBarrageOfEmail().ToObservable();
            var inboxBuffer = inbox.Throttle(TimeSpan.FromSeconds(1));
            inboxBuffer.Subscribe(emails => {
                System.Console.WriteLine($"You've got {emails.Count()} new messages!  Here they are!");
                foreach (var email in emails) {
                    System.Console.WriteLine("> {0}", email);
                }
            });
        }

        private static IEnumerable<string> EndlessBarrageOfEmail() {
            var random = new Random();

            var emails = new List<string> {"Here is an email, DUDE!"};
            for (int i = default; i < 6; i++) {
                yield return emails[random.Next(emails.Count)];
                Thread.Sleep(random.Next(1000));
            }
        }

        private static void OneNumberPerSecond() {
            var observable = Observable.Interval(TimeSpan.FromSeconds(1));
            System.Console.WriteLine("Numbers <= 8:");
            observable.Where(n => n <= 8)
                .Select(n => n)
                .Subscribe(value => { System.Console.WriteLine(value.ToString()); });
        }

        private static void ConvertToObservable() {
            var someListValues = new List<int> {1, 2, 3, 4, 5};
            var observable = someListValues.ToObservable();
            observable.Subscribe((value) => { System.Console.WriteLine(value.ToString()); });
        }

        public static IDisposable ObservableRange() {
            var observableRange = Observable.Range(1, 10);
            return observableRange.Subscribe(
                x => System.Console.WriteLine("OnNext: {0}", x),
                ex => System.Console.WriteLine("OnError: {0}", ex.Message),
                () => System.Console.WriteLine("OnCompleted"));
        }

        public static async void ParallelExecution() {
            var observable = Observable.CombineLatest(
                Observable.Start(() => {
                    System.Console.WriteLine("Executing 1st on Thread: {0}", Thread.CurrentThread.ManagedThreadId);
                    return "Result A";
                }),
                Observable.Start(() => {
                    System.Console.WriteLine("Executing 2nd on Thread: {0}", Thread.CurrentThread.ManagedThreadId);
                    return "Result B";
                }),
                Observable.Start(() => {
                    System.Console.WriteLine("Executing 3rd on Thread: {0}", Thread.CurrentThread.ManagedThreadId);
                    return "Result C";
                })
            ).Finally(() => System.Console.WriteLine("Done!"));
            var observables = await observable.FirstAsync();
            foreach (var o in observables)
                System.Console.WriteLine(o);
        }
    }
}