using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Helmer.Shared.Tools.Reactive;

/// <summary>
/// Reactive extension on the BehaviourSubject, Distinct Until Changed
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class DistinctBehaviorSubject<T>
{
    protected DistinctBehaviorSubject(T init)
    {
        Subject = new BehaviorSubject<T>(init);
    }

    public T Value
    {
        get => Subject.Value;
        set => Subject.OnNext(value);
    }

    public BehaviorSubject<T> Subject { get; private set; }

    /// <summary>
    /// When the Value changed
    /// </summary>
    public IObservable<T> ValueChanged => Subject.DistinctUntilChanged();
}