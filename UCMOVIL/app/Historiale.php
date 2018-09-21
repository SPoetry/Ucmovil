<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Historiale extends Model
{
  use Notifiable;

  /**
   * The attributes that are mass assignable.
   *
   * @var array
   */
  protected $fillable = [
      'id_asignatura', 'id_alumno', 'estado',
      'semestre', 'nota_final',
  ];
  public function asignatura(){
    return $this->belongsTo('App\Asignatura');
  }
  public function alumno(){
    return $this->belongsTo('App\Alumno');
  }
}
