<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class RamosActuale extends Model
{
  protected $fillable = [
      'id_asignatura', 'id_alumno',
  ];
  public function alumno(){
    return $this->belongsTo('App\Alumno');
  }
  public function asignatura(){
    return $this->belongsTo('App\Asignatura');
  }
}
