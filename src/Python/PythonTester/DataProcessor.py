import os

f = open('../Data/' + 'RESULTS-FINAL.txt', 'w+')
f.write('')
f.close()

for file in os.listdir('../Data/'):
    if file == "RESULTS-FINAL.txt" or file.startswith('py'):
        continue

    f = open('../Data/' + file, 'r')
    times = f.read()
    times = times[0:len(times) - 1]
    f.close()

    timesSplit = times.split(',')

    timeCount = 0
    timeTotal = 0

    for time in timesSplit:
        timeCount = timeCount + 1
        timeTotal = timeTotal + int(time)

    timeAverage = timeTotal / timeCount

    f = open('../Data/' + 'RESULTS-FINAL.txt', 'a+')
    f.write(file + ': ' + str(timeAverage) + '\r\n')
    f.close()
