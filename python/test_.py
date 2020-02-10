
import time
import datetime

a = '[{"PercentProcessorTime": "None", "Name": "0"},{"PercentProcessorTime": "None", "Name": "1"},{"PercentProcessorTime": "None", "Name": "2"},{"PercentProcessorTime": "0", "Name": "3"}]'
print(a.replace('None', '0'))