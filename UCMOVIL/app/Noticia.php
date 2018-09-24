<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Noticia extends Model
{
  protected $fillable = [
      'id_noticia', 'texto', 'estado',
      'propietario', 
  ];
}
