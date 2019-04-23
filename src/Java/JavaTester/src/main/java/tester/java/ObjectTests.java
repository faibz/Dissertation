package tester.java;

import org.openjdk.jmh.annotations.*;
import tester.java.Objects.Object;

import java.util.*;
import java.util.concurrent.TimeUnit;

public class ObjectTests {

    @State(Scope.Thread)
    public static class SmallObjectTestsState {
        private Random random = new Random();
        public Deque<Object> stack = new ArrayDeque<Object>();;
        public Queue<Object> queue = new LinkedList<Object>();
        public LinkedList<Object> linkedList = new LinkedList<Object>();
        public ArrayList<Object> list = new ArrayList<Object>();
        public HashMap<Integer, Object> dictionary = new HashMap<Integer, Object>();

        private Object object = new Object();

        @Param({"1", "10", "1000", "10000"})
        public int Count;
        public int Target = -1;

        @Setup(Level.Invocation)
        public void setup() {
            Target = random.nextInt(Count);

            for(int i = 0; i < Count; ++i) {
                linkedList.addLast(object);
            }

            for(int i = 0; i < Count; ++i) {
                list.add(object);
            }

            for(int i = 0; i < Count; ++i) {
                dictionary.put(i, object);
            }
        }

        @TearDown(Level.Invocation)
        public void tearDown() {
            stack.clear();
            queue.clear();
            linkedList.clear();
            list.clear();
            dictionary.clear();
        }
    }

    @Benchmark @BenchmarkMode(Mode.SampleTime) @OutputTimeUnit(TimeUnit.NANOSECONDS)
    public void LifoTests(SmallObjectTestsState state) {
        for (int i = 0; i < state.Count; ++i) {
            state.stack.push(state.object);
        }

        for (int i = 0; i < state.Count; ++i) {
            state.stack.pop();
        }
    }

    @Benchmark @BenchmarkMode(Mode.SampleTime) @OutputTimeUnit(TimeUnit.NANOSECONDS)
    public void FifoTests(SmallObjectTestsState state) {
        for (int i = 0; i < state.Count; ++i) {
            state.queue.add(state.object);
        }

        for (int i = 0; i < state.Count; ++i) {
            state.queue.remove();
        }
    }

    @Benchmark @BenchmarkMode(Mode.SampleTime) @OutputTimeUnit(TimeUnit.NANOSECONDS)
    public int SequentialAccessTests(SmallObjectTestsState state) {
        return state.linkedList.lastIndexOf(state.Count - 1);
    }

    @Benchmark @BenchmarkMode(Mode.SampleTime) @OutputTimeUnit(TimeUnit.NANOSECONDS)
    public Object IndexAccessTests(SmallObjectTestsState state) {
        return state.list.get(state.Target);
    }

    @Benchmark @BenchmarkMode(Mode.SampleTime) @OutputTimeUnit(TimeUnit.NANOSECONDS)
    public Object KeyAccessTests(SmallObjectTestsState state) {
        return state.dictionary.get(state.Target);
    }
}
