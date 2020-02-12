# -*- coding: utf-8 -*-

import logging
import logging.handlers
from logging.handlers import TimedRotatingFileHandler
import time

logInitCfg = dict()
logInitCfg['cfg'] = {      
        'console':True,
        'logPath':".log",
        'debug':False,
        }


def getLogger(logName):
    logCfg = logInitCfg['cfg']
    _logger = logging.getLogger(logName)
    LOGGING_FORMAT = '%(asctime)s '+logName+' %(levelname)s => %(message)s'
    DATE_FORMAT = '%Y-%m-%d %H:%M:%S'
    handlerformatter = logging.Formatter(LOGGING_FORMAT, DATE_FORMAT)
    if logCfg['console']:
        consolehandler =logging.StreamHandler()
        consolehandler.setFormatter(handlerformatter)
        _logger.addHandler(consolehandler)
    filePath = logCfg['logPath']
    if filePath:
        '''
        fileTimeHandler = TimedRotatingFileHandler(filePath, "D", 1)
        th = handlers.TimedRotatingFileHandler(filename=filename, when='S', backupCount=3, encoding='utf-8')
        fileTimeHandler.suffix = "%Y-%m-%d.log"
        fileTimeHandler.setFormatter(handlerformatter)
        _logger.addHandler(fileTimeHandler)
        '''

        filehandler = logging.FileHandler(filePath)
        filehandler.setFormatter(handlerformatter)
        _logger.addHandler(filehandler)
        
    if logCfg['debug']:
        _logger.setLevel(logging.DEBUG)
    else:
        _logger.setLevel(logging.INFO)  
    return _logger
