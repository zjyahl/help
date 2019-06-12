<?php
urlencode(json_encode($array, JSON_UNESCAPED_UNICODE));

ob_start(); 
ob_implicit_flush(false);
echo "ddd";
ob_get_clean();
//ob_end_flush();

extract ( array &$array [, int $flags = EXTR_OVERWRITE [, string $prefix = NULL ]] ) 