# import io
# import pstats
import collections
import random
import cProfile


class IndexRetrievalTests:
    _list = []
    interation_count = 0;
    _target = 0

    def setup(self, iteration_count, target):
        self._target = target

        for x in range(iteration_count):
            self._list.append(x)

    def test(self):
        return self._list[self._target]

    def cleanup(self):
        self._list.clear()


index_tester = IndexRetrievalTests()

index_tester.setup(1, 0)
cProfile.run('index_tester.test()', '../Data/prim-index-1')
index_tester.cleanup()

index_tester.setup(10, random.randint(0, 9))
cProfile.run('index_tester.test()', '../Data/prim-index-10')
index_tester.cleanup()

index_tester.setup(1000, random.randint(0, 999))
cProfile.run('index_tester.test()', '../Data/prim-index-1000')
index_tester.cleanup()

index_tester.setup(10000, random.randint(0, 9999))
cProfile.run('index_tester.test()', '../Data/prim-index-10000')
index_tester.cleanup()


class FifoTests:
    iteration_count = 0
    deque = collections.deque()

    def setup(self, iteration_count):
        self.iteration_count = iteration_count

    def test(self):
        for x in range(self.iteration_count):
            self.deque.append(x)

        for x in range(self.iteration_count):
            self.deque.popleft()


fifo_tester = FifoTests()

fifo_tester.setup(1)
cProfile.run('fifo_tester.test()')

fifo_tester.setup(10)
cProfile.run('fifo_tester.test()')

fifo_tester.setup(1000)
cProfile.run('fifo_tester.test()')

fifo_tester.setup(10000)
cProfile.run('fifo_tester.test()')

fifo_tester.setup(1000000)
cProfile.run('fifo_tester.test()')


class LifoTests:
    iteration_count = 0
    deque = collections.deque()

    def setup(self, iteration_count):
        self.iteration_count = iteration_count

    def test(self):
        for x in range(self.iteration_count):
            self.deque.append(x)

        for x in range(self.iteration_count):
            self.deque.pop()


lifo_tester = LifoTests()

lifo_tester.setup(1)
cProfile.run('lifo_tester.test()')

lifo_tester.setup(10)
cProfile.run('lifo_tester.test()')

lifo_tester.setup(1000)
cProfile.run('lifo_tester.test()')

lifo_tester.setup(10000)
cProfile.run('lifo_tester.test()')

lifo_tester.setup(1000000)
cProfile.run('lifo_tester.test()')


class KeyRetrievalTests:
    _dict = {}
    _target = 0

    def setup(self, iteration_count, target):
        self._target = target

        for x in range(iteration_count):
            self._dict[x] = x

    def test(self):
        return self._dict.get(self._target)

    def cleanup(self):
        self._dict.clear()


key_tester = KeyRetrievalTests()

key_tester.setup(1, 0)
cProfile.run('lifo_tester.test()')
key_tester.cleanup()

key_tester.setup(10, random.randint(0, 9))
cProfile.run('key_tester.test()')
key_tester.cleanup()

key_tester.setup(1000, random.randint(0, 999))
cProfile.run('key_tester.test()')
key_tester.cleanup()

key_tester.setup(10000, random.randint(0, 9999))
cProfile.run('key_tester.test()')
key_tester.cleanup()


class SequentialTests:
    iteration_count = 0
    deque = collections.deque()

    def setup(self, iteration_count):
        self.iteration_count = iteration_count

        for x in range(self.iteration_count):
            self.deque.append(x)

    def test(self):
        return self.deque.index(self.iteration_count - 1)

    def cleanup(self):
        for x in range(self.iteration_count):
            self.deque.pop()


sequential_tester = SequentialTests()

sequential_tester.setup(1)
cProfile.run('sequential_tester.test()')
sequential_tester.cleanup()

sequential_tester.setup(10)
cProfile.run('sequential_tester.test()')
sequential_tester.cleanup()

sequential_tester.setup(1000)
cProfile.run('sequential_tester.test()')
sequential_tester.cleanup()

sequential_tester.setup(10000)
cProfile.run('sequential_tester.test()')
sequential_tester.cleanup()
