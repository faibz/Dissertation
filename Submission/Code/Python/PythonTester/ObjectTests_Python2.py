import time
import random
import collections

from Objects.Object import Object


class IndexRetrievalTests:
    _list = []
    _target = 0
    _object = Object()

    def setup(self, iteration_count, target):
        self._target = target

        for x in range(iteration_count):
            self._list.append(self._object)

    def test(self):
        return self._list[self._target]

    def cleanup(self):
        self._list[:] = []


index_tester = IndexRetrievalTests()

index_tester.setup(1, 0)

startTime = time.clock()

index_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/obj-index-1.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

index_tester.cleanup()

index_tester.setup(10, random.randint(0, 9))

startTime = time.clock()

index_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/obj-index-10.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

index_tester.cleanup()

index_tester.setup(1000, random.randint(0, 999))

startTime = time.clock()

index_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/obj-index-1000.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

index_tester.cleanup()

index_tester.setup(10000, random.randint(0, 9999))

startTime = time.clock()

index_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/obj-index-10000.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

index_tester.cleanup()


class FifoTests:
    _iteration_count = 0
    _deque = collections.deque()
    _object = Object()

    def setup(self, iteration_count):
        self._iteration_count = iteration_count

    def test(self):
        for x in range(self._iteration_count):
            self._deque.append(self._object)

        for x in range(self._iteration_count):
            self._deque.popleft()


fifo_tester = FifoTests()

fifo_tester.setup(1)

startTime = time.clock()

fifo_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/obj-fifo-1.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

fifo_tester.setup(10)

startTime = time.clock()

fifo_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/obj-fifo-10.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

fifo_tester.setup(1000)

startTime = time.clock()

fifo_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/obj-fifo-1000.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

fifo_tester.setup(10000)

startTime = time.clock()

fifo_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/obj-fifo-10000.txt', 'a+')
f.write('%d,' % time_taken)
f.close()


class LifoTests:
    _iteration_count = 0
    _deque = collections.deque()
    _object = Object()

    def setup(self, iteration_count):
        self._iteration_count = iteration_count

    def test(self):
        for x in range(self._iteration_count):
            self._deque.append(self._object)

        for x in range(self._iteration_count):
            self._deque.pop()


lifo_tester = LifoTests()

lifo_tester.setup(1)

startTime = time.clock()

lifo_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/obj-lifo-1.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

lifo_tester.setup(10)

startTime = time.clock()

lifo_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/obj-lifo-10.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

lifo_tester.setup(1000)

startTime = time.clock()

lifo_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/obj-lifo-1000.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

lifo_tester.setup(10000)

startTime = time.clock()

lifo_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/obj-lifo-10000.txt', 'a+')
f.write('%d,' % time_taken)
f.close()


class KeyRetrievalTests:
    _dict = {}
    _target = 0
    _object = Object()

    def setup(self, iteration_count, target):
        self._target = target

        for x in range(iteration_count):
            self._dict[x] = self._object

    def test(self):
        return self._dict.get(self._target)

    def cleanup(self):
        self._dict.clear()


key_tester = KeyRetrievalTests()

key_tester.setup(1, 0)

startTime = time.clock()

key_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/obj-key-1.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

key_tester.cleanup()

key_tester.setup(10, random.randint(0, 9))

startTime = time.clock()

key_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/obj-key-10.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

key_tester.cleanup()

key_tester.setup(1000, random.randint(0, 999))

startTime = time.clock()

key_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/obj-key-1000.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

key_tester.cleanup()

key_tester.setup(10000, random.randint(0, 9999))

startTime = time.clock()

key_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/obj-key-10000.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

key_tester.cleanup()


class SequentialTests:
    _iteration_count = 0
    _deque = collections.deque()
    _object = Object()
    _lastObject = Object()

    def setup(self, iteration_count):
        self._iteration_count = iteration_count
        self._lastObject._intProp = 10

        for x in range(self._iteration_count - 1):
            self._deque.append(self._object)

        self._deque.append(self._lastObject)

    def test(self):
        return self._deque.remove(self._lastObject)

    def cleanup(self):
        self._deque.clear()


sequential_tester = SequentialTests()

sequential_tester.setup(1)

startTime = time.clock()

sequential_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/obj-sequential-1.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

sequential_tester.cleanup()

sequential_tester.setup(10)

startTime = time.clock()

sequential_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/obj-sequential-10.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

sequential_tester.cleanup()

sequential_tester.setup(1000)

startTime = time.clock()

sequential_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/obj-sequential-1000.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

sequential_tester.cleanup()

sequential_tester.setup(10000)

startTime = time.clock()

sequential_tester.test()

time_taken = (time.clock() - startTime) * 1000000000

f = open('../Data/obj-sequential-10000.txt', 'a+')
f.write('%d,' % time_taken)
f.close()

sequential_tester.cleanup()
