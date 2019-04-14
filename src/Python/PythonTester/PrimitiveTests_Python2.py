import time
import random
import collections


class IndexRetrievalTests:
    _list = []
    _target = 0

    def setup(self, iteration_count, target):
        self._target = target

        for x in range(iteration_count):
            self._list.append(x)

    def test(self):
        return self._list[self._target]

    def cleanup(self):
        self._list[:] = []


index_tester = IndexRetrievalTests()

index_tester.setup(1, 0)

startTime = time.clock()

index_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/prim-index-1.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

index_tester.cleanup()

index_tester.setup(10, random.randint(0, 9))

startTime = time.clock()

index_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/prim-index-10.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

index_tester.cleanup()

index_tester.setup(1000, random.randint(0, 999))

startTime = time.clock()

index_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/prim-index-1000.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

index_tester.cleanup()

index_tester.setup(10000, random.randint(0, 9999))

startTime = time.clock()

index_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/prim-index-10000.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

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

startTime = time.clock()

fifo_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/prim-fifo-1.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

fifo_tester.setup(10)

startTime = time.clock()

fifo_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/prim-fifo-10.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

fifo_tester.setup(1000)

startTime = time.clock()

fifo_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/prim-fifo-1000.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

fifo_tester.setup(10000)

startTime = time.clock()

fifo_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/prim-fifo-10000.txt', 'a+')
f.write('%d,' % time_taken)
f.close()


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

startTime = time.clock()

lifo_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/prim-lifo-1.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

lifo_tester.setup(10)

startTime = time.clock()

lifo_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/prim-lifo-10.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

lifo_tester.setup(1000)

startTime = time.clock()

lifo_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/prim-lifo-1000.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

lifo_tester.setup(10000)

startTime = time.clock()

lifo_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/prim-lifo-10000.txt', 'a+')
f.write('%d,' % time_taken)
f.close()


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

startTime = time.clock()

key_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/prim-key-1.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

key_tester.cleanup()

key_tester.setup(10, random.randint(0, 9))

startTime = time.clock()

key_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/prim-key-10.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

key_tester.cleanup()

key_tester.setup(1000, random.randint(0, 999))

startTime = time.clock()

key_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/prim-key-1000.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

key_tester.cleanup()

key_tester.setup(10000, random.randint(0, 9999))

startTime = time.clock()

key_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/prim-key-10000.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

key_tester.cleanup()


class SequentialTests:
    iteration_count = 0
    deque = collections.deque()

    def setup(self, iteration_count):
        self.iteration_count = iteration_count

        for x in range(self.iteration_count):
            self.deque.append(x)

    def test(self):
        return self.deque.remove(self.iteration_count - 1)

    def cleanup(self):
        self.deque.clear()


sequential_tester = SequentialTests()

sequential_tester.setup(1)

startTime = time.clock()

sequential_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/prim-sequential-1.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

sequential_tester.cleanup()

sequential_tester.setup(10)

startTime = time.clock()

sequential_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/prim-sequential-10.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

sequential_tester.cleanup()

sequential_tester.setup(1000)

startTime = time.clock()

sequential_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/prim-sequential-1000.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

sequential_tester.cleanup()

sequential_tester.setup(10000)

startTime = time.clock()

sequential_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/prim-sequential-10000.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

sequential_tester.cleanup()
