<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Secretaria extends Model
{
  protected $fillable = [
      'id_secretaria', 'nombre', 'email',
      'telefono',
  ];

  public function user(){
    return $this->hasOne('App\User');
  }
}
