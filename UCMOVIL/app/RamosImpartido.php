<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class RamosImpartido extends Model
{
  protected $fillable = [
      'id_asignatura', 'id_profesor',
  ];
  public function profesore(){
    return $this->belongsTo('App\Profesore');
  }
  public function asignatura(){
    return $this->belongsTo('App\Asignatura');
  }
}
