<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Profesore extends Model
{
  protected $fillable = [
      'id_profesor', 'ano_ingreso', 'especialidad',
      'nombre', 'email', 'telefono',
  ];

  public function user(){
    return $this->belongTo(User::class, 'id_profesor', 'id');
  }
  public function ramosimpartido(){
    return $this->hasMany('App\RamosImpartido');
  }
}
