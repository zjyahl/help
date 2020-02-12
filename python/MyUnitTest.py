import unittest
from unittest.mock import Mock
from unittest.mock import patch
from unittest.mock import MagicMock
from unittest.mock import create_autospec
from types import MethodType



class SomeClass():

    @staticmethod
    def static_method(a):
        return a
    def add(self, a ,b):
        return a + b

class MyUnitTest(unittest.TestCase):
    mock_static_mthed= Mock(return_value='Guy')

    @classmethod
    def setUpClass(cls):
        print('setUpClass')
    @classmethod
    def tearDownClass(cls):
        print('tearDownClass')

    def setUp(self):
        print('setUp...')
    
    def tearDown(self):
        print('tearDown...')

    @unittest.skip('skip')
    def test111(self):
        a = SomeClass()
        #a.add = create_autospec(a.add, return_value=11)
        #a.add = create_autospec(a.add, side_effect=[11, 22, 12])
        #a.add = create_autospec(a.add, side_effect=lambda x,y:x-y)
        a.add = create_autospec(a.add,side_effect=KeyError('integer type'))
        self.assertRaises(KeyError, a.add,1,2)
 
    @patch('__main__.SomeClass.static_method')
    def test_mock_static_mthed(self, mock_static_mthed):
        mock_static_mthed.return_value = 'Guy'
        self.assertEqual(mock_static_mthed(12), 'Guy')
        self.assertEqual(SomeClass.static_method(12), 'Guy')

  
    @patch.object(SomeClass, 'static_method', mock_static_mthed)
    def test_mock_static_mthed3(self):
        self.assertEqual(SomeClass.static_method(12), 'Guy')

    def test_mock_static_mthed4(self):
        mock_get_class_name = Mock(return_value='Guy')
        with patch.object(SomeClass, 'static_method', mock_get_class_name):
            self.assertEqual(SomeClass.static_method(12), 'Guy')
 
        self.assertEqual(SomeClass.static_method(12), 12)
    
    



if __name__ == '__main__':
    test_suite = unittest.TestSuite()#
    #test_suite.addTest(MyUnitTest('test111'))
    test_suite.addTests(unittest.makeSuite(MyUnitTest))
    runner = unittest.TextTestRunner()
    runner.run(test_suite)