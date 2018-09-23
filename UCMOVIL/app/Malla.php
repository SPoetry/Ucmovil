<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Malla extends Model
{
  protected $fillable = [
      'id_asignatura', 'semestre', 'nombre',
  ];
  public function asignatura(){
    return $this->belongsTo(Asignatura::class, 'id_asignatura', 'id_asignatura');
  }
}
