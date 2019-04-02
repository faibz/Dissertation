package tester.java;

import org.openjdk.jmh.annotations.*;

import java.util.*;
import java.util.concurrent.TimeUnit;

public class PrimitiveTests {

    @State(Scope.Thread)
    public static class PrimitiveTestsState {
        private Random random = new Random();
        public Deque<Integer> stack = new ArrayDeque<Integer>();;
        public Queue<Integer> queue = new LinkedList<Integer>();
        public LinkedList<Integer> linkedList = new LinkedList<Integer>();
        public ArrayList<Integer> list = new ArrayList<Integer>();
        public HashMap<Integer, Integer> dictionary = new HashMap<Integer, Integer>();
        public int Count = 1;
        public int Target = -1;

        @Setup(Level.Trial)
        public void setup() {
            Target = random.nextInt(Count);

            for(int i = 0; i < Count; ++i) {
                linkedList.addLast(i);
            }

            for(int i = 0; i < Count; ++i) {
                list.add(i);
            }

            for(int i = 0; i < Count; ++i) {
                dictionary.put(i, i);
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
    public void LifoTests(PrimitiveTestsState state) {
        for (int i = 0; i < state.Count; ++i) {
            state.stack.push(i);
        }

        for (int i = 0; i < state.Count; ++i) {
            state.stack.pop();
        }
    }

    @Benchmark @BenchmarkMode(Mode.SampleTime) @OutputTimeUnit(TimeUnit.NANOSECONDS)
    public void FifoTests(PrimitiveTestsState state) {
        for (int i = 0; i < state.Count; ++i) {
            state.queue.add(i);
        }

        for (int i = 0; i < state.Count; ++i) {
            state.queue.remove();
        }
    }

    @Benchmark @BenchmarkMode(Mode.SampleTime) @OutputTimeUnit(TimeUnit.NANOSECONDS)
    public int SequentialAccessTests(PrimitiveTestsState state) {
        return state.linkedList.lastIndexOf(state.Count - 1);
    }

    @Benchmark @BenchmarkMode(Mode.SampleTime) @OutputTimeUnit(TimeUnit.NANOSECONDS)
    public int IndexAccessTests(PrimitiveTestsState state) {
        return state.list.get(state.Target);
    }

    @Benchmark @BenchmarkMode(Mode.SampleTime) @OutputTimeUnit(TimeUnit.NANOSECONDS)
    public int KeyAccessTests(PrimitiveTestsState state) {
        return state.dictionary.get(state.Target);
    }
}
