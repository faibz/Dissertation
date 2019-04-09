package tester.java;

import org.openjdk.jmh.annotations.*;
import tester.java.Objects.SmallObject;

import java.util.*;
import java.util.concurrent.TimeUnit;

public class SmallObjectTests {

    @State(Scope.Thread)
    public static class SmallObjectTestsState {
        private Random random = new Random();
        public Deque<SmallObject> stack = new ArrayDeque<SmallObject>();;
        public Queue<SmallObject> queue = new LinkedList<SmallObject>();
        public LinkedList<SmallObject> linkedList = new LinkedList<SmallObject>();
        public ArrayList<SmallObject> list = new ArrayList<SmallObject>();
        public HashMap<Integer, SmallObject> dictionary = new HashMap<Integer, SmallObject>();

        private SmallObject smallObject = new SmallObject();

        @Param({"1", "10", "1000", "10000"})
        public int Count;
        public int Target = -1;

        @Setup(Level.Invocation)
        public void setup() {
            Target = random.nextInt(Count);

            for(int i = 0; i < Count; ++i) {
                linkedList.addLast(smallObject);
            }

            for(int i = 0; i < Count; ++i) {
                list.add(smallObject);
            }

            for(int i = 0; i < Count; ++i) {
                dictionary.put(i, smallObject);
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
            state.stack.push(state.smallObject);
        }

        for (int i = 0; i < state.Count; ++i) {
            state.stack.pop();
        }
    }

    @Benchmark @BenchmarkMode(Mode.SampleTime) @OutputTimeUnit(TimeUnit.NANOSECONDS)
    public void FifoTests(SmallObjectTestsState state) {
        for (int i = 0; i < state.Count; ++i) {
            state.queue.add(state.smallObject);
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
    public SmallObject IndexAccessTests(SmallObjectTestsState state) {
        return state.list.get(state.Target);
    }

    @Benchmark @BenchmarkMode(Mode.SampleTime) @OutputTimeUnit(TimeUnit.NANOSECONDS)
    public SmallObject KeyAccessTests(SmallObjectTestsState state) {
        return state.dictionary.get(state.Target);
    }
}
