<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Horario extends Model
{
  protected $fillable = [
      'id_asignatura', 'modulo', 'dia',
      'creditos',
  ];
  public function asignatura(){
    return $this->belongsTo('App\Asignatura');
  }
}
