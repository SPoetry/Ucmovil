<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Nota extends Model
{
  protected $fillable = [
      'id_alumno', 'id_asignatura', 'nota',
      'N_nota',
  ];
  public function alumno(){
    return $this->belongsTo('App\Alumno');
  }
  public function asignatura(){
    return $this->belongsTo('App\Asignatura');
  }
}
